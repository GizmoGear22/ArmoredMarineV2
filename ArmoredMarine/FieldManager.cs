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

        public int DistanceBetween()
        {
            int Distance = PlayerPosition + CompPosition;
            return Distance;
        }

        public void ReducePlayerPosition()
        {
            PlayerPosition -= 10;
        }

        public void ReduceCompPosition()
        {
            CompPosition -= 10;
        }

        
        

    }
}
