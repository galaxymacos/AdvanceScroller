// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""621039be-7ad0-4de7-b2ca-b58933d081cf"",
            ""actions"": [
                {
                    ""name"": ""Run"",
                    ""type"": ""PassThrough"",
                    ""id"": ""aced843d-1a5e-4967-810c-b09c5cff600b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""817c3b2f-1cbc-4a70-bf50-7b3afee04ca8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""1e0eaeed-4369-411b-b89a-64f427edf0f4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""5267eb09-6b26-4574-bccb-631f2599292a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill1"",
                    ""type"": ""Button"",
                    ""id"": ""9fa1dbb3-01de-49a3-843e-38693338990c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill2"",
                    ""type"": ""Button"",
                    ""id"": ""9d96a0b6-0458-4240-a21d-a1700c450dab"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill3"",
                    ""type"": ""Button"",
                    ""id"": ""0a35dbb0-0500-4990-81bd-2e18b33d3912"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill4"",
                    ""type"": ""Button"",
                    ""id"": ""702ce3e2-25ff-437f-b91e-6847f8935aee"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""VerticalMovement"",
                    ""type"": ""Button"",
                    ""id"": ""f1673e26-d8d8-4fc0-839a-cb0570e166d5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cdd09132-d6f7-4430-9aa6-7179d7da4dd6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""29ffbf4a-2a47-44c4-93d3-cff4a147dda0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""743aff48-02ce-4f5c-9870-407515b6810a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8202e95b-4ae2-430c-89a5-724afd38d9f1"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""35897038-b114-490a-bc53-e48110cd2f8b"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6eab921f-e0a7-487c-9256-0d25c0bcde55"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbe9920c-5867-480d-b011-548f12e42ded"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13826233-807c-4176-b0cf-b44be3e25208"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""001d11c3-9c0b-44e0-8591-7f429963ba8e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34fd2b2e-b1c0-4f20-b2a3-4fc75a3dffac"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""7d08d8d3-d1ff-4248-8201-d5f483bbe1bd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""391c29cb-92ec-4f67-8a4f-4f57a91fb959"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""115373d7-b932-4dd3-ba86-097f78fc59a1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""fe5db749-5242-4937-9d04-db8148817f14"",
            ""actions"": [
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""b42afc15-25e9-4063-9631-d394b7341f7e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""5ef2a26d-30aa-4d72-9244-829b7f6d1dd3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""553ff393-d5b2-475d-8533-db4635b7adcc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""e2598a80-4bee-4597-9004-34d2c43a0bb3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill1"",
                    ""type"": ""Button"",
                    ""id"": ""f3f340d0-f65b-4e42-ac18-13a7ba371b71"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill2"",
                    ""type"": ""Button"",
                    ""id"": ""f4a7f0cc-09b4-4bc5-981b-2fdcdffb29d3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill3"",
                    ""type"": ""Button"",
                    ""id"": ""6c1c5336-bb08-40ab-b38a-8f792ae9c523"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Skill4"",
                    ""type"": ""Button"",
                    ""id"": ""a6f042df-c21e-4a5a-8ad2-3bc2e1d8e5da"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""VerticalMovement"",
                    ""type"": ""Button"",
                    ""id"": ""b11f95de-b7f1-428e-8696-bf24e9f68127"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""7d8d39c1-64f6-4574-9f64-484d3d1edd59"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3022c720-df33-4195-beb2-076f5bca9900"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f89364f6-573e-493f-8219-941c60602c18"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""24df2bbb-2341-406d-8a97-a27f29e75549"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c006ffea-f1f7-4bd6-a658-3526872821f8"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4ef46b4-7639-44a5-891e-d8172058dea3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97f90d30-dfa2-432d-b56c-48be8f9890ed"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bed0d42-18c9-4f00-b6c8-2764c042f28e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a23dde56-e73b-49fe-8044-f3d0de925cd5"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2822a4fe-62e6-40f0-80ba-08ce558ba913"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""b1997ef3-543f-4aac-804e-e603e4331065"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6d3559a4-0ee2-4731-b946-6b5eb3a58ba1"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9c0d9784-5f24-4153-b980-2b340aa46e5c"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""PlayerNew"",
            ""id"": ""18183bd2-e48e-45ca-a792-7467f2810d44"",
            ""actions"": [
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""8b987ae3-96b4-499b-97af-d9d8744be0d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""99903109-689b-42ed-baca-8c3f77319d83"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""AttackRelease"",
                    ""type"": ""Button"",
                    ""id"": ""288ec4c9-b7c2-4e25-b42a-128938528c5e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""91bfa257-a4b3-483f-a599-dd3e58edd117"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""0a7baa22-fe3f-4d9f-91bb-65e8a93b4dfc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""DashRelease"",
                    ""type"": ""Button"",
                    ""id"": ""8e2cbd46-8e76-46d7-9235-8f7bcad3c1f7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Skill1"",
                    ""type"": ""Button"",
                    ""id"": ""ec8346d2-3ceb-49e3-8618-54f0c81efd5a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Skill1Release"",
                    ""type"": ""Button"",
                    ""id"": ""ff2e6572-25c3-40f9-b1bd-f73dd32c7a54"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Skill2"",
                    ""type"": ""Button"",
                    ""id"": ""98244462-8769-40e0-91a5-1ab983cb0238"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Skill2Release"",
                    ""type"": ""Button"",
                    ""id"": ""ef698740-914b-4219-9be9-b92294d88194"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Skill3"",
                    ""type"": ""Button"",
                    ""id"": ""43cc4348-958d-46ba-8757-a6ea08a8a899"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Skill3Release"",
                    ""type"": ""Button"",
                    ""id"": ""33e1254c-bcd0-47e3-a454-6b4b8bb20343"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Skill4"",
                    ""type"": ""Button"",
                    ""id"": ""3d4ce1d0-61af-4deb-add0-92484eb750c5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Skill4Release"",
                    ""type"": ""Button"",
                    ""id"": ""22de61d8-68cd-4abc-95b1-0c41f6e890bd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""VerticalMovement"",
                    ""type"": ""Button"",
                    ""id"": ""febbdbe0-e260-4e78-b987-ec168c31cb51"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""JumpRelease"",
                    ""type"": ""Button"",
                    ""id"": ""53b92a0d-b452-4b3b-ab15-5a8eddb6ade1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""2ff9f64d-065c-4010-8a75-fc80f791d808"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Joystick"",
                    ""id"": ""2a1273bf-ca69-4d68-8233-364809e8c858"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""098a2993-b450-43ed-b8a8-f51242dce068"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""68dee8b4-7e81-4c73-9471-70eeaaf3f881"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""ca89d141-5663-4857-9def-5f87c1bb26bf"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""99f7d1ae-e96b-446a-967e-ce2749250356"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""10b27c1f-d0d6-4dac-8a1c-d416f0f15841"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cb85266a-89fb-49a7-9f97-cc03f97b741c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""556999c8-cefa-47bb-95da-8c6b231b80d8"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""659a6d15-3616-4ec3-9d95-4610b9579e6d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5f84abb-6c34-43b2-96d7-0e259fee83ff"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""786d816f-411f-423f-b173-888d8fbaa6bc"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d61f52a-712c-4e4d-b948-be85a8ba8a7f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""968cf034-360e-4be8-9cca-7cd25d90202b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af9007b8-2acc-410f-91e6-008c08930e3c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0fba75a0-8aa6-44ee-8e79-a32dc124b7db"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2978166f-8919-460e-8fe1-fa91055ea239"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5c52869-0168-4dcc-acaf-93298ebb4085"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e389647a-de73-453b-8a21-a3b4ab76ce9c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b09af76e-e96f-4d37-a616-cf661ed20984"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b6d7873-7325-4043-a419-ad938d2d5c2b"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""6961d38b-e157-4ab4-a1ff-508836db3847"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2c614935-517d-476c-9b1d-2aae422ee5e3"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a3f8c3b2-441c-44d3-958b-f02d026b5fe7"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""d1870cb8-8be8-43d2-9736-fb9ff8b81a8e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""da3b2910-d632-47cf-9ed6-15a002738303"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a925f06f-9ce4-43a7-9547-ff1416e69d89"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""026ffd1f-33f9-42fe-8a9b-bff17358230d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ac4a319-7ac8-45dc-87d4-7cec5996b1b9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3565831a-c2d5-4a73-82d5-ded8d1fae138"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09e2b533-7d3e-44a3-8d72-dd60debe0351"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76e64cd2-7a0d-45db-87b1-b95338f6515d"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill1Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9cd9b02-d2b2-4396-b8ef-72029cbed75a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill1Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ba55736-ad5b-44db-aa0d-8b2d35f01a34"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill2Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c04545d-81db-43b5-9223-c4df9bc0dd39"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill2Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33bffdb9-5b12-4f31-9c67-3f442ad9e9f6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill3Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06456e2f-6bf1-4723-9cf9-5ffc2046d4b9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill3Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e34b0eb-4c92-473d-ba10-e4eb8992c17e"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill4Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ec77451-c0ce-4075-8f2b-69ba323e8c76"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill4Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fdaabc43-7853-4ee1-bf8f-d29939adcb24"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69f20a26-c3cf-409e-91a3-a9a25b8dfb2f"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f208e1c0-de8a-47db-af7e-0ba3063e4578"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11b88dd1-0a01-4f10-b207-d60abec690dc"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Skill1 = m_Player.FindAction("Skill1", throwIfNotFound: true);
        m_Player_Skill2 = m_Player.FindAction("Skill2", throwIfNotFound: true);
        m_Player_Skill3 = m_Player.FindAction("Skill3", throwIfNotFound: true);
        m_Player_Skill4 = m_Player.FindAction("Skill4", throwIfNotFound: true);
        m_Player_VerticalMovement = m_Player.FindAction("VerticalMovement", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_Run = m_Player2.FindAction("Run", throwIfNotFound: true);
        m_Player2_Attack = m_Player2.FindAction("Attack", throwIfNotFound: true);
        m_Player2_Jump = m_Player2.FindAction("Jump", throwIfNotFound: true);
        m_Player2_Dash = m_Player2.FindAction("Dash", throwIfNotFound: true);
        m_Player2_Skill1 = m_Player2.FindAction("Skill1", throwIfNotFound: true);
        m_Player2_Skill2 = m_Player2.FindAction("Skill2", throwIfNotFound: true);
        m_Player2_Skill3 = m_Player2.FindAction("Skill3", throwIfNotFound: true);
        m_Player2_Skill4 = m_Player2.FindAction("Skill4", throwIfNotFound: true);
        m_Player2_VerticalMovement = m_Player2.FindAction("VerticalMovement", throwIfNotFound: true);
        // PlayerNew
        m_PlayerNew = asset.FindActionMap("PlayerNew", throwIfNotFound: true);
        m_PlayerNew_Run = m_PlayerNew.FindAction("Run", throwIfNotFound: true);
        m_PlayerNew_Attack = m_PlayerNew.FindAction("Attack", throwIfNotFound: true);
        m_PlayerNew_AttackRelease = m_PlayerNew.FindAction("AttackRelease", throwIfNotFound: true);
        m_PlayerNew_Jump = m_PlayerNew.FindAction("Jump", throwIfNotFound: true);
        m_PlayerNew_Dash = m_PlayerNew.FindAction("Dash", throwIfNotFound: true);
        m_PlayerNew_DashRelease = m_PlayerNew.FindAction("DashRelease", throwIfNotFound: true);
        m_PlayerNew_Skill1 = m_PlayerNew.FindAction("Skill1", throwIfNotFound: true);
        m_PlayerNew_Skill1Release = m_PlayerNew.FindAction("Skill1Release", throwIfNotFound: true);
        m_PlayerNew_Skill2 = m_PlayerNew.FindAction("Skill2", throwIfNotFound: true);
        m_PlayerNew_Skill2Release = m_PlayerNew.FindAction("Skill2Release", throwIfNotFound: true);
        m_PlayerNew_Skill3 = m_PlayerNew.FindAction("Skill3", throwIfNotFound: true);
        m_PlayerNew_Skill3Release = m_PlayerNew.FindAction("Skill3Release", throwIfNotFound: true);
        m_PlayerNew_Skill4 = m_PlayerNew.FindAction("Skill4", throwIfNotFound: true);
        m_PlayerNew_Skill4Release = m_PlayerNew.FindAction("Skill4Release", throwIfNotFound: true);
        m_PlayerNew_VerticalMovement = m_PlayerNew.FindAction("VerticalMovement", throwIfNotFound: true);
        m_PlayerNew_JumpRelease = m_PlayerNew.FindAction("JumpRelease", throwIfNotFound: true);
        m_PlayerNew_Pause = m_PlayerNew.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Skill1;
    private readonly InputAction m_Player_Skill2;
    private readonly InputAction m_Player_Skill3;
    private readonly InputAction m_Player_Skill4;
    private readonly InputAction m_Player_VerticalMovement;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Skill1 => m_Wrapper.m_Player_Skill1;
        public InputAction @Skill2 => m_Wrapper.m_Player_Skill2;
        public InputAction @Skill3 => m_Wrapper.m_Player_Skill3;
        public InputAction @Skill4 => m_Wrapper.m_Player_Skill4;
        public InputAction @VerticalMovement => m_Wrapper.m_Player_VerticalMovement;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Skill1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill1;
                @Skill1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill1;
                @Skill1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill1;
                @Skill2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill2;
                @Skill2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill2;
                @Skill2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill2;
                @Skill3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill3;
                @Skill3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill3;
                @Skill3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill3;
                @Skill4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill4;
                @Skill4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill4;
                @Skill4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSkill4;
                @VerticalMovement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalMovement;
                @VerticalMovement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalMovement;
                @VerticalMovement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalMovement;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Skill1.started += instance.OnSkill1;
                @Skill1.performed += instance.OnSkill1;
                @Skill1.canceled += instance.OnSkill1;
                @Skill2.started += instance.OnSkill2;
                @Skill2.performed += instance.OnSkill2;
                @Skill2.canceled += instance.OnSkill2;
                @Skill3.started += instance.OnSkill3;
                @Skill3.performed += instance.OnSkill3;
                @Skill3.canceled += instance.OnSkill3;
                @Skill4.started += instance.OnSkill4;
                @Skill4.performed += instance.OnSkill4;
                @Skill4.canceled += instance.OnSkill4;
                @VerticalMovement.started += instance.OnVerticalMovement;
                @VerticalMovement.performed += instance.OnVerticalMovement;
                @VerticalMovement.canceled += instance.OnVerticalMovement;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_Run;
    private readonly InputAction m_Player2_Attack;
    private readonly InputAction m_Player2_Jump;
    private readonly InputAction m_Player2_Dash;
    private readonly InputAction m_Player2_Skill1;
    private readonly InputAction m_Player2_Skill2;
    private readonly InputAction m_Player2_Skill3;
    private readonly InputAction m_Player2_Skill4;
    private readonly InputAction m_Player2_VerticalMovement;
    public struct Player2Actions
    {
        private @PlayerInputActions m_Wrapper;
        public Player2Actions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Run => m_Wrapper.m_Player2_Run;
        public InputAction @Attack => m_Wrapper.m_Player2_Attack;
        public InputAction @Jump => m_Wrapper.m_Player2_Jump;
        public InputAction @Dash => m_Wrapper.m_Player2_Dash;
        public InputAction @Skill1 => m_Wrapper.m_Player2_Skill1;
        public InputAction @Skill2 => m_Wrapper.m_Player2_Skill2;
        public InputAction @Skill3 => m_Wrapper.m_Player2_Skill3;
        public InputAction @Skill4 => m_Wrapper.m_Player2_Skill4;
        public InputAction @VerticalMovement => m_Wrapper.m_Player2_VerticalMovement;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @Run.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRun;
                @Attack.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnAttack;
                @Jump.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnDash;
                @Skill1.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSkill1;
                @Skill1.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSkill1;
                @Skill1.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSkill1;
                @Skill2.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSkill2;
                @Skill2.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSkill2;
                @Skill2.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSkill2;
                @Skill3.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSkill3;
                @Skill3.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSkill3;
                @Skill3.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSkill3;
                @Skill4.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSkill4;
                @Skill4.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSkill4;
                @Skill4.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnSkill4;
                @VerticalMovement.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnVerticalMovement;
                @VerticalMovement.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnVerticalMovement;
                @VerticalMovement.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnVerticalMovement;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Skill1.started += instance.OnSkill1;
                @Skill1.performed += instance.OnSkill1;
                @Skill1.canceled += instance.OnSkill1;
                @Skill2.started += instance.OnSkill2;
                @Skill2.performed += instance.OnSkill2;
                @Skill2.canceled += instance.OnSkill2;
                @Skill3.started += instance.OnSkill3;
                @Skill3.performed += instance.OnSkill3;
                @Skill3.canceled += instance.OnSkill3;
                @Skill4.started += instance.OnSkill4;
                @Skill4.performed += instance.OnSkill4;
                @Skill4.canceled += instance.OnSkill4;
                @VerticalMovement.started += instance.OnVerticalMovement;
                @VerticalMovement.performed += instance.OnVerticalMovement;
                @VerticalMovement.canceled += instance.OnVerticalMovement;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);

    // PlayerNew
    private readonly InputActionMap m_PlayerNew;
    private IPlayerNewActions m_PlayerNewActionsCallbackInterface;
    private readonly InputAction m_PlayerNew_Run;
    private readonly InputAction m_PlayerNew_Attack;
    private readonly InputAction m_PlayerNew_AttackRelease;
    private readonly InputAction m_PlayerNew_Jump;
    private readonly InputAction m_PlayerNew_Dash;
    private readonly InputAction m_PlayerNew_DashRelease;
    private readonly InputAction m_PlayerNew_Skill1;
    private readonly InputAction m_PlayerNew_Skill1Release;
    private readonly InputAction m_PlayerNew_Skill2;
    private readonly InputAction m_PlayerNew_Skill2Release;
    private readonly InputAction m_PlayerNew_Skill3;
    private readonly InputAction m_PlayerNew_Skill3Release;
    private readonly InputAction m_PlayerNew_Skill4;
    private readonly InputAction m_PlayerNew_Skill4Release;
    private readonly InputAction m_PlayerNew_VerticalMovement;
    private readonly InputAction m_PlayerNew_JumpRelease;
    private readonly InputAction m_PlayerNew_Pause;
    public struct PlayerNewActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerNewActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Run => m_Wrapper.m_PlayerNew_Run;
        public InputAction @Attack => m_Wrapper.m_PlayerNew_Attack;
        public InputAction @AttackRelease => m_Wrapper.m_PlayerNew_AttackRelease;
        public InputAction @Jump => m_Wrapper.m_PlayerNew_Jump;
        public InputAction @Dash => m_Wrapper.m_PlayerNew_Dash;
        public InputAction @DashRelease => m_Wrapper.m_PlayerNew_DashRelease;
        public InputAction @Skill1 => m_Wrapper.m_PlayerNew_Skill1;
        public InputAction @Skill1Release => m_Wrapper.m_PlayerNew_Skill1Release;
        public InputAction @Skill2 => m_Wrapper.m_PlayerNew_Skill2;
        public InputAction @Skill2Release => m_Wrapper.m_PlayerNew_Skill2Release;
        public InputAction @Skill3 => m_Wrapper.m_PlayerNew_Skill3;
        public InputAction @Skill3Release => m_Wrapper.m_PlayerNew_Skill3Release;
        public InputAction @Skill4 => m_Wrapper.m_PlayerNew_Skill4;
        public InputAction @Skill4Release => m_Wrapper.m_PlayerNew_Skill4Release;
        public InputAction @VerticalMovement => m_Wrapper.m_PlayerNew_VerticalMovement;
        public InputAction @JumpRelease => m_Wrapper.m_PlayerNew_JumpRelease;
        public InputAction @Pause => m_Wrapper.m_PlayerNew_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PlayerNew; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerNewActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerNewActions instance)
        {
            if (m_Wrapper.m_PlayerNewActionsCallbackInterface != null)
            {
                @Run.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnRun;
                @Attack.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnAttack;
                @AttackRelease.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnAttackRelease;
                @AttackRelease.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnAttackRelease;
                @AttackRelease.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnAttackRelease;
                @Jump.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnDash;
                @DashRelease.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnDashRelease;
                @DashRelease.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnDashRelease;
                @DashRelease.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnDashRelease;
                @Skill1.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill1;
                @Skill1.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill1;
                @Skill1.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill1;
                @Skill1Release.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill1Release;
                @Skill1Release.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill1Release;
                @Skill1Release.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill1Release;
                @Skill2.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill2;
                @Skill2.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill2;
                @Skill2.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill2;
                @Skill2Release.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill2Release;
                @Skill2Release.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill2Release;
                @Skill2Release.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill2Release;
                @Skill3.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill3;
                @Skill3.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill3;
                @Skill3.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill3;
                @Skill3Release.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill3Release;
                @Skill3Release.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill3Release;
                @Skill3Release.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill3Release;
                @Skill4.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill4;
                @Skill4.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill4;
                @Skill4.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill4;
                @Skill4Release.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill4Release;
                @Skill4Release.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill4Release;
                @Skill4Release.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnSkill4Release;
                @VerticalMovement.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnVerticalMovement;
                @VerticalMovement.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnVerticalMovement;
                @VerticalMovement.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnVerticalMovement;
                @JumpRelease.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnJumpRelease;
                @Pause.started -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerNewActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerNewActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @AttackRelease.started += instance.OnAttackRelease;
                @AttackRelease.performed += instance.OnAttackRelease;
                @AttackRelease.canceled += instance.OnAttackRelease;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @DashRelease.started += instance.OnDashRelease;
                @DashRelease.performed += instance.OnDashRelease;
                @DashRelease.canceled += instance.OnDashRelease;
                @Skill1.started += instance.OnSkill1;
                @Skill1.performed += instance.OnSkill1;
                @Skill1.canceled += instance.OnSkill1;
                @Skill1Release.started += instance.OnSkill1Release;
                @Skill1Release.performed += instance.OnSkill1Release;
                @Skill1Release.canceled += instance.OnSkill1Release;
                @Skill2.started += instance.OnSkill2;
                @Skill2.performed += instance.OnSkill2;
                @Skill2.canceled += instance.OnSkill2;
                @Skill2Release.started += instance.OnSkill2Release;
                @Skill2Release.performed += instance.OnSkill2Release;
                @Skill2Release.canceled += instance.OnSkill2Release;
                @Skill3.started += instance.OnSkill3;
                @Skill3.performed += instance.OnSkill3;
                @Skill3.canceled += instance.OnSkill3;
                @Skill3Release.started += instance.OnSkill3Release;
                @Skill3Release.performed += instance.OnSkill3Release;
                @Skill3Release.canceled += instance.OnSkill3Release;
                @Skill4.started += instance.OnSkill4;
                @Skill4.performed += instance.OnSkill4;
                @Skill4.canceled += instance.OnSkill4;
                @Skill4Release.started += instance.OnSkill4Release;
                @Skill4Release.performed += instance.OnSkill4Release;
                @Skill4Release.canceled += instance.OnSkill4Release;
                @VerticalMovement.started += instance.OnVerticalMovement;
                @VerticalMovement.performed += instance.OnVerticalMovement;
                @VerticalMovement.canceled += instance.OnVerticalMovement;
                @JumpRelease.started += instance.OnJumpRelease;
                @JumpRelease.performed += instance.OnJumpRelease;
                @JumpRelease.canceled += instance.OnJumpRelease;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerNewActions @PlayerNew => new PlayerNewActions(this);
    public interface IPlayerActions
    {
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnSkill1(InputAction.CallbackContext context);
        void OnSkill2(InputAction.CallbackContext context);
        void OnSkill3(InputAction.CallbackContext context);
        void OnSkill4(InputAction.CallbackContext context);
        void OnVerticalMovement(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnRun(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnSkill1(InputAction.CallbackContext context);
        void OnSkill2(InputAction.CallbackContext context);
        void OnSkill3(InputAction.CallbackContext context);
        void OnSkill4(InputAction.CallbackContext context);
        void OnVerticalMovement(InputAction.CallbackContext context);
    }
    public interface IPlayerNewActions
    {
        void OnRun(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnAttackRelease(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnDashRelease(InputAction.CallbackContext context);
        void OnSkill1(InputAction.CallbackContext context);
        void OnSkill1Release(InputAction.CallbackContext context);
        void OnSkill2(InputAction.CallbackContext context);
        void OnSkill2Release(InputAction.CallbackContext context);
        void OnSkill3(InputAction.CallbackContext context);
        void OnSkill3Release(InputAction.CallbackContext context);
        void OnSkill4(InputAction.CallbackContext context);
        void OnSkill4Release(InputAction.CallbackContext context);
        void OnVerticalMovement(InputAction.CallbackContext context);
        void OnJumpRelease(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
