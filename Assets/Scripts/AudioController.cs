using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public bool debug;
    public AudioTrack[] tracks;

    private Dictionary<AudioType, AudioTrack> m_AudioTable; // relationshiop between audio types (key) and audio tracks (value)
    private Dictionary<AudioType, IEnumerator> m_JobTable; // relationship between audio types (key) and jobs (value) (Coroutine, IEnumnerator)

    

    [Serializable]
    public class AudioTrack
    {
        public AudioSource source;
        public AudioObject[] audio;
    }

    private class AudioJob
    {
        public readonly AudioAction action;
        public readonly AudioType type;
        public readonly bool fade;
        public readonly float delay;
        public readonly bool loop;

        public AudioJob(AudioAction action, AudioType type, bool _fade, float _delay, bool loop)
        {
            this.action = action;
            this.type = type;
            this.fade = _fade;
            this.delay = _delay;
            this.loop = loop;
        }
    }

    private enum AudioAction
    {
        START,
        STOP, 
        RESTART
    }

    #region Unity Functions

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Configure();
        }
    }

    private void OnDisable()
    {
        Dispose();
    }

    

    #endregion

    #region Public Functions

    public void PlayAudio(AudioType _type, bool _fade = false, float _delay = 0.0f, bool _loop = false)
    {
        if (_type == AudioType.None) return;
        Addjob(new AudioJob(AudioAction.START, _type, _fade, _delay, _loop));
    }

    public void StopAudio(AudioType _type, bool _fade = false, float _delay = 0.0f)
    {
        if (_type == AudioType.None) return;
        Addjob(new AudioJob(AudioAction.STOP, _type, _fade, _delay, false));
    }

    public void RestartAudio(AudioType _type, bool _fade = false, float _delay = 0.0f)
    {
        if (_type == AudioType.None) return;
        Addjob(new AudioJob(AudioAction.RESTART, _type, _fade, _delay, false));

    }

    #endregion

    #region Private Functions

    
    private void Configure()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        m_AudioTable = new Dictionary<AudioType, AudioTrack>();
        m_JobTable = new Dictionary<AudioType, IEnumerator>();
        GenerateAudioTable();
    }
    private void Dispose()
    {
        if (m_JobTable == null)
        {
            Log("Currently there is no sound job in the table. Terminating...");
            return;
        }
        foreach (var _entry in m_JobTable.Keys)
        {
            StopCoroutine(m_JobTable[_entry]);
        }
    }

    private void GenerateAudioTable()
    {
        foreach (AudioTrack _track in tracks)
        {
            foreach (AudioObject _obj in _track.audio)
            {
                if (m_AudioTable.ContainsKey(_obj.type))
                {
                    LogWarning($"You are trying to register audio [{_obj.type}] that has already been registered");
                }
                else
                {
                    m_AudioTable.Add(_obj.type, _track);
                    Log($"Registering audio {_obj.type}.");
                }
            }
        }
    }

    private void Log(string _msg)
    {
        if (!debug) return;
        Debug.Log("[Audio Controller]: " + _msg);
    }

    private void LogWarning(string _msg)
    {
        if (!debug) return;
    }

    private void Addjob(AudioJob _job)
    {
        // Remove conflicting jobs
        RemoveConflictingJobs(_job.type);
        
        //Start job
        IEnumerator _jobRunner = RunAudioJob(_job);
        m_JobTable.Add(_job.type, _jobRunner);
        StartCoroutine(_jobRunner);
        Log("Starting job on ["+_job.type+"] with operation: "+_job.action);
    }
    
    private IEnumerator RunAudioJob(AudioJob _job)
    {
        yield return new WaitForSeconds(_job.delay);

        if (!m_AudioTable.ContainsKey(_job.type))
        {
            print($"The audio job doesn't contain the type {_job.type.ToString()}");
            
        }
        AudioTrack _track = m_AudioTable[_job.type];
        _track.source.clip = GetAudioClipFromAudioTrack(_job.type, _track);

        switch (_job.action)
        {
            case AudioAction.START: 
                _track.source.Play();
                _track.source.loop = _job.loop;
                break;
            
            case AudioAction.STOP:
                if (!_job.fade)
                {
                    _track.source.Stop();
                }
                break;
            case AudioAction.RESTART:
                _track.source.Stop();
                _track.source.Play();
                break;
        }

        if (_job.fade)
        {
            float _initial = _job.action == AudioAction.START || _job.action == AudioAction.RESTART ? 0 : 1;
            float _target = Math.Abs(_initial) < Mathf.Epsilon ? 1 : 0;
            float _duration = 1f;
            float _timer = 0f;
            while (_timer <= _duration)
            {
                _track.source.volume = Mathf.Lerp(_initial, _target, _timer / _duration);
                _timer += Time.deltaTime;
                yield return null;
            }

            if (_job.action == AudioAction.STOP)
            {
                _track.source.Stop();
            }
        }
        
        m_JobTable.Remove(_job.type);
        Log($"Job count: {m_JobTable.Count}");
        yield return null;
    }

    private AudioClip GetAudioClipFromAudioTrack(AudioType _type, AudioTrack _track)
    {
        foreach (AudioObject _obj in _track.audio)
        {
            if (_obj.type == _type)
            {
                return _obj.clip;
            }
        }

        return null;
    }

    private void RemoveConflictingJobs(AudioType _type)
    {
        if (m_JobTable.ContainsKey(_type))
        {
            RemoveJob(_type);
        }

        AudioType _conflictingAudio = AudioType.None;
        foreach (var _entry in m_JobTable.Keys)
        {
            AudioType _audioType = _entry;
            AudioTrack _audioTrackInUse = m_AudioTable[_audioType];
            AudioTrack _audioTrackNeeded = m_AudioTable[_type];
            if (_audioTrackNeeded.source == _audioTrackInUse.source)
            {
                // Conflict
                _conflictingAudio = _audioType;
            }
        }

        if (_conflictingAudio != AudioType.None)
        {
            RemoveJob(_conflictingAudio);
        }
    }

    private void RemoveJob(AudioType _type)
    {
        if (!m_JobTable.ContainsKey(_type))
        {
            LogWarning("Trying to stop a job ["+_type+"] that is not running.");
            return;
        }

        IEnumerator _runningJob = m_JobTable[_type];
        StopCoroutine(_runningJob);
        m_JobTable.Remove(_type);
    }

    #endregion
}