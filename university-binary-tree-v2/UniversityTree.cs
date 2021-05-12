using System;
using System.Collections.Generic;
using System.Text;

namespace university_binary_tree_v2
{
    class UniversityTree
    {
        public PositionNode Root;
        float tempValue = 0;
        public PositionNode NodeTemp = null;
        //Crear nodo
        public void CreatePosition(PositionNode parent, Position positionToCreate, String parentPositionName)
        {
            PositionNode newNode = new PositionNode();
            newNode.Position = positionToCreate;

            if (Root == null)
            {
                Root = newNode;
                return;
            }

            if (parent == null)
            {
                return;
            }

            if (parent.Position.Name == parentPositionName)
            {
                if (parent.Left == null)
                {
                    parent.Left = newNode;
                    return;
                }
                parent.Right = newNode;
                return;
            }

            CreatePosition(parent.Left, positionToCreate, parentPositionName);
            CreatePosition(parent.Right, positionToCreate, parentPositionName);
        }
        //Imprimir arbol
        public void PrintTree(PositionNode from)
        {
            if (from == null)
            {
                return;
            }

            Console.WriteLine("{0,25} {1,6} {2,6} {3,8}", $"{from.Position.Name}:",
                $"{from.Position.Salary}", $"{from.Position.RentPercent}", $"{from.Position.RentValue}");

            PrintTree(from.Left);
            PrintTree(from.Right);
        }
        //Sumar salarios
        public float AddSalaries(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }

            return from.Position.Salary + AddSalaries(from.Left) + AddSalaries(from.Right);

        }

        //Salario mas largo 
        public float HigherSalary(PositionNode from)
        {
            if (from != null)
            {
                if (tempValue < from.Position.Salary)
                {
                    tempValue = from.Position.Salary;
                }

                float tempValueLeft = HigherSalary(from.Left);
                float tempValueRight = HigherSalary(from.Right);

                if (tempValueLeft > tempValueRight)
                {
                    return tempValueLeft;
                }

                return tempValueRight;
            }

            return tempValue;
        }

        //Calcular el salario promedio
        public PositionNode SearchNode(PositionNode from, String searchPosition)
        {
            if (from != null)
            {
                //PREGUNTO SI EL NODO EN EL QUE ESTOY ES IGUAL AL CARGO A BUSCAR 
                if (from.Position.Name.Equals(searchPosition))
                {
                    return from;
                }
                else
                {
                    //ALMACENO EN EL NODO TEMPORAL LA BUSQUEDA DE LA IZQUIERDA
                    NodeTemp = SearchNode(from.Left, searchPosition);
                    if (NodeTemp == null)
                    {
                        NodeTemp = SearchNode(from.Right, searchPosition);
                    }
                }
            }
            return NodeTemp;
        }

        //Contar nodos 
        public float Count(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }

            float countLeft = Count(from.Left);
            float countRight = Count(from.Right);

            return countLeft + countRight + 1;
        }
        //Sumar impuestos
        public float AddRents(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }

            return from.Position.RentValue + AddRents(from.Left) + AddRents(from.Right);

        }

    
    }
}
