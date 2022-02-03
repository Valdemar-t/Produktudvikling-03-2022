using SilentWolfHelper.Debugger;

namespace Interactable
{
    public class Sign : Interactable
    {
        protected internal override void Interaction()
        {
            if (gameManager.debug) DebugSW.Log("Hi, I am a sign", this);
        }
    }
}