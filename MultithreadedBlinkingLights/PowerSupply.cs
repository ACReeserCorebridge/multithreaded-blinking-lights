using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadedBlinkingLights
{
    public class PowerSupply : IPowerSupply
    {
        IPhotonExciter _exciter;

        private bool powerSwitchIsOn = false;
        private Task current;

        public PowerSupply(IPhotonExciter exciter)
        {
            _exciter = exciter;
        }

        public void TurnOn()
        {
            powerSwitchIsOn = true;
            current = Task.Run(RunCurrent);
        }

        public void TurnOff()
        {
            powerSwitchIsOn = false;
        }

        public async Task RunCurrent()
        {
            while (powerSwitchIsOn)
            {
                await _exciter.Emit();
                await Task.Delay(100);
            }
        }
    }
}
