﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        { 
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private static int _nomber;
            private double _sum;
            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return null;
                    double[] Coefs = new double[_coefs.Length];
                    for (int i = 0; i < Coefs.Length; i++) Coefs[i] = _coefs[i];
                    return Coefs;
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] Marks = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < Marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < Marks.GetLength(1); j++)
                        {
                            Marks[i, j] = _marks[i, j];
                        }

                    }
                    return Marks;
                }
            }
            public double TotalScore
            {
                get
                {
                    return _sum;
                }

            }
            public void Sum()
            {
                double sum = 0;

                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    int min = int.MaxValue;
                    int max = int.MinValue;
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        sum += _marks[i, j] * _coefs[i];
                        if (min > _marks[i, j]) min = _marks[i, j];
                        if (max < _marks[i, j]) max = _marks[i, j];
                    }
                    sum -= (min + max) * _coefs[i];

                }
                _sum = sum;
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                _sum = 0;
            }
            public void SetCriterias(double[] coefs)
            {
                if (coefs.Length == 4&& coefs!=null)
                {
                    for (int i = 0; i < coefs.Length; i++)
                    {
                        _coefs[i] = coefs[i];
                    }
                }
            }
            public void Jump(int[] marks)
            {
                if(_nomber==4)_nomber = 0;
                if (marks == null || _marks == null || _coefs == null) return;
                if (marks.Length == 7)
                {
                    for (int i = 0; i < marks.Length; i++)
                    {
                        _marks[_nomber, i] = marks[i];
                    }
                    _nomber++;
                }
            }
            public static void Sort( Participant[] array)
            { 
                if(array==null) return;
                for (int i = 1; i < array.Length;)
                {
                    if (i == 0 || array[i].TotalScore <= array[i - 1].TotalScore)
                    {
                        i++;
                    }
                    else
                    {
                        Participant temp1 = array[i];
                        array[i] = array[i - 1];
                        array[i-1] = temp1;
                        i--;
                    }
                }
                
            }
         
            public void Print()
            {
                Console.Write(_name+" ");
                Console.Write(_surname + " ");
                Console.WriteLine(_sum);
            }
        }
 
    }
}

