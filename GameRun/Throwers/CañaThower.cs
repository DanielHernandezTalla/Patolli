using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.Throwers
{
    public class CañaThower : IThrower
    {
        private int quantity = 5;
        private int result;
        private bool[] cañas;
        public bool IsEnable { get; set; }
        public bool CañasThrown { get; private set; }

        public void RollCañas()
        {
            // Logica de tirar cañas.
            Random random = new Random();
            cañas = new bool[quantity];
            int counter = 0;

            for (int i = 0; i < quantity; i++)
            {
                // Se asigna el resultado de la caña.
                bool cañaResult = (random.Next(2) == 0) ? false : true;
                cañas[i] = cañaResult;

                if (cañaResult) counter++;
            }

            // Si las 5 cañas cayeron bien el resultado sera 10. 
            // Si no, el resultado sera igual a la cantidad de cañas que cayeron bien.
            if (counter == 5) result = 10;
            else result = counter;

            CañasThrown = true;
        }
        
        public bool[] GetCañas()
        {
            return cañas;
        }

        public int GetResult()
        {
            return result;
        }

        public void Reset()
        {
            cañas = null;
            result = 0;

            CañasThrown = false;
        }

    }
}
