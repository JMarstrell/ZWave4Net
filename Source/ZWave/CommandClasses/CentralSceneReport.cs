using System;
using System.Collections.Generic;
using System.Text;
using ZWave.Channel.Protocol;

namespace ZWave.CommandClasses
{
    public enum CentralSceneKeyState
    {
        KeyPressed1Time = 0x00,
        KeyReleased = 0x01,
        KeyHeldDown = 0x02,
        KeyPressed2Times = 0x03,
        KeyPressed3Times = 0x04,
        KeyPressed4Times = 0x05,
        KeyPressed5Times = 0x06
    }

    public class CentralSceneReport : NodeReport
    {
        public readonly byte SequenceNumber;
        public readonly CentralSceneKeyState KeyState;
        public readonly byte SceneNumber;

        internal CentralSceneReport(Node node, byte[] payload) : base(node)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));
            if (payload.Length < 3)
                throw new ReponseFormatException($"The response was not in the expected format. {GetType().Name}: Payload: {BitConverter.ToString(payload)}");

            SequenceNumber = payload[0];
            KeyState = (CentralSceneKeyState)(payload[1] & 0x07);
            SceneNumber = payload[2];
        }

        public override string ToString()
        {
            return $"Sequence:{SequenceNumber}, KeyState:{KeyState}, Scene:{SceneNumber}";
        }
    }
}
