namespace Effects
{
    public class TakeStaminaDamage : InstantCharacterEffects
    {
        public override void ProcessEffect(CharacterManager character)
        {
            base.ProcessEffect(character);
        }
        
        private void CalculateStaminaDamage(PlayerManager character)
        {
            character.player.currentStamina -= 10;
        }
    }
}