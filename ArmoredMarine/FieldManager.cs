using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmoredMarine
{
    public class FieldManager
    {
        public int PlayerPosition { get; set; }
        public int CompPosition { get; set; }


        public FieldManager(int playerPosition, int compPosition)
        {
            PlayerPosition = playerPosition;
            CompPosition = compPosition;
        }

        public int DistanceBetweenCharacters()
        {
            int Distance = PlayerPosition + CompPosition;
            return Distance;
        }

        public void ChangePlayerPosition(MarineCharacter character)
        {
            PlayerPosition -= character.MovementDistance;
        }

        public void ChangeComputerPosition(MarineCharacter character)
        {
            CompPosition -= character.MovementDistance; 
        }
        
        

    }
}
