using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public enum LeastCommonUnit
    {
        Dot = 0,
        Space = 1,
        Dash = 2

    }
    public class MorseNode 
    {
        
        public LeastCommonUnit value;
        public char ch = '\0'; // default to nothing
        public MorseNode left;
        public MorseNode center;
        public MorseNode right;
    }
    public class Morsetree
    {
        private MorseNode start = null;

        public void Insert(MorseNode root, MorseNode node)
        {
            if (start == null)
            {
                // ignore root
                this.start = node;
                return;
            }

            switch (node.value)
            {
                case LeastCommonUnit.Dash:
                    root.right = node; break;

                case LeastCommonUnit.Dot:
                    root.left = node; break;

                case LeastCommonUnit.Space:
                    root.center = node; break;

            }
        }

        public string Fetch()
        {
            string s = null;
            MorseNode temp = root;
            while (temp != null)
            {
                char ch = GetNextChar(temp);
                s.Insert(0, temp)
            }


        }

        private MorseNode GetNextNode(MorseNode node, LeastCommonUnit leastCommonUnit)
        {

            MorseNode nodeToreturn = null;
            if (leastCommonUnit == LeastCommonUnit.Dash)
            {
                nodeToreturn = node.right;
            }
            else if (leastCommonUnit == LeastCommonUnit.Dot)
            {
                nodeToreturn = node.left;
            }
            else if (leastCommonUnit == LeastCommonUnit.Space)
            {
                nodeToreturn = node.center;
            }
            else throw new SystemException("Can't find leastCommonUnit");          
            
            if (nodeToreturn == null)
            {
                throw new SystemException("Can't find Node to return");
            }
            return nodeToreturn;


        }

        public void PopulateTree()
        {
            LeastCommonUnit[] LeastCommonUnitStreamA = { LeastCommonUnit.Dot, LeastCommonUnit.Space, LeastCommonUnit.Dash };
            LeastCommonUnit[] LeastCommonUnitStreamB = { LeastCommonUnit.Dash, LeastCommonUnit.Dot, LeastCommonUnit.Dot, LeastCommonUnit.Dot };
            LeastCommonUnit[] LeastCommonUnitStreamC = { LeastCommonUnit.Dash, LeastCommonUnit.Dot, LeastCommonUnit.Dash, LeastCommonUnit.Dot };
            LeastCommonUnit[] LeastCommonUnitStreamD = { LeastCommonUnit.Dash, LeastCommonUnit.Dot, LeastCommonUnit.Dot};
            LeastCommonUnit[] LeastCommonUnitStreamE = { LeastCommonUnit.Dot };
            LeastCommonUnit[] LeastCommonUnitStreamF = { LeastCommonUnit.Dot, LeastCommonUnit.Dot, LeastCommonUnit.Dash, LeastCommonUnit.Dot };
            LeastCommonUnit[] LeastCommonUnitStreamG = { LeastCommonUnit.Dash, LeastCommonUnit.Dash, LeastCommonUnit.Dot };
            LeastCommonUnit[] LeastCommonUnitStreamH = { LeastCommonUnit.Dot, LeastCommonUnit.Dot, LeastCommonUnit.Dot, LeastCommonUnit.Dot };
            LeastCommonUnit[] LeastCommonUnitStreamI = { LeastCommonUnit.Dot, LeastCommonUnit.Dot };
            LeastCommonUnit[] LeastCommonUnitStreamJ = { LeastCommonUnit.Dot, LeastCommonUnit.Dash, LeastCommonUnit.Dash, LeastCommonUnit.Dash};
            PopulateCharInTree('a', LeastCommonUnitStreamA);
            PopulateCharInTree('b', LeastCommonUnitStreamB);
            PopulateCharInTree('c', LeastCommonUnitStreamC);
            PopulateCharInTree('d', LeastCommonUnitStreamD);
            PopulateCharInTree('e', LeastCommonUnitStreamE);
            PopulateCharInTree('f', LeastCommonUnitStreamF);
            PopulateCharInTree('g', LeastCommonUnitStreamG);
            PopulateCharInTree('h', LeastCommonUnitStreamH);
            PopulateCharInTree('i', LeastCommonUnitStreamI);

        }

        public void PopulateCharInTree(char ch, LeastCommonUnit[] LeastCommonUnitStream)
        {
            for (int i=0; i< LeastCommonUnitStream.Length; i++)
            {
                MorseNode temp = new MorseNode();
                temp.value = LeastCommonUnitStream[i];
                if(i== LeastCommonUnitStream.Length -1)
                {
                    //add the char to the last node
                    temp.ch = ch;
                }
                        
                this.Insert(this.start, temp);
            }
        }
    }
}
