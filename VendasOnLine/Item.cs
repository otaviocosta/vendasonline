﻿namespace VendasOnLine
{
    public class Item
    {
        public string Descricao { get; private set; }
        public double Valor { get; private set; }
        public int Quantidade { get; private set; }
        public double Total => Quantidade * Valor;

        public Item(string descricao, double valor, int quantidade)
        {
            Descricao = descricao;
            Valor = valor;
            Quantidade = quantidade;
        }

    }
}
