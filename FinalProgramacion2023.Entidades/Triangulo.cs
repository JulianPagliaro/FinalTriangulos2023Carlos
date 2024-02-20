namespace FinalProgramacion2023.Entidades
{
    public class Triangulo
    {
        public int Lado1 { get; set; }
        public int Lado2 { get; set; }
        public int Lado3 { get; set; }
        public int Perimetro { get; set; }
        private TipoDeBorde tipoDeBorde;

        public TipoDeBorde TipoDeBorde
        {
            get { return tipoDeBorde; }
            set { tipoDeBorde = value; }
        }

        private ColorRelleno colorRelleno;

        public ColorRelleno ColorRelleno
        {
            get { return colorRelleno; }
            set { colorRelleno = value; }
        }
        public Triangulo()
        {
        }
        public Triangulo(int lado1, int lado2, int lado3, TipoDeBorde borde, ColorRelleno color)
        {
            Lado1 = lado1;
            Lado2 = lado2;
            Lado3 = lado3;
            TipoDeBorde = borde;
            ColorRelleno = color;
        }
        public double GetLado1() => Lado1;
        public void SetLado1(int medida1)
        {
            if (medida1 > 0)
            {
                Lado1 = medida1;
            }
        }
        public double GetLado2() => Lado2;
        public void SetLado2(int medida2)
        {
            if (medida2 > 0)
            {
                Lado2 = medida2;
            }
        }

        public double GetLado3() => Lado3;
        public void SetLado3(int medida3)
        {
            if (medida3 > 0)
            {
                Lado3 = medida3;
            }
        }

        public double GetPerimetro() => (Lado1) + (Lado2) + (Lado3);
        public double GetArea() => Math.Sqrt(GetPerimetro() * (GetPerimetro() - GetLado1()) * (GetPerimetro() - GetLado2()) * (GetPerimetro() - GetLado3()));
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public string GetTriangleType()
        {
            if (Lado1 == Lado2 && Lado1 == Lado3)
                return "Equilátero";
            else if (Lado1 + Lado2 <= Lado3 || Lado1 + Lado3 <= Lado2 || Lado2 + Lado3 <= Lado1)
                return "Indeterminado";
            else if (Lado1 == Lado2 || Lado1 == Lado3 || Lado2 == Lado3)
                return "Isóceles";
            else
                return "Escaleno";
        }
    }
}
