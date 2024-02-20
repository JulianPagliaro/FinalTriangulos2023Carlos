using FinalProgramacion2023.Entidades;

namespace FinalProgramacion2023.Datos
{
    public class RepositorioDeTriangulos
    {
        private readonly string _archivo = Environment.CurrentDirectory + "//Triangulos.txt";
        private readonly string _archivoCopia = Environment.CurrentDirectory + "//Triangulos.bak";

        private List<Triangulo> listaTriang;
        public RepositorioDeTriangulos()
        {
            listaTriang = new List<Triangulo>();
            LeerDatos();
        }

        private void LeerDatos()
        {
            listaTriang.Clear();
            if (File.Exists(_archivo))
            {
                var lector = new StreamReader(_archivo);
                while (!lector.EndOfStream)
                {
                    string lineaLeida = lector.ReadLine();
                    Triangulo triangulo = ConstruirTriangulo(lineaLeida);
                    listaTriang.Add(triangulo);
                }
                lector.Close();
            }
        }
        public void Editar(Triangulo triViejo, Triangulo trianguloEditar)
        {
            using (var lector = new StreamReader(_archivo))
            {
                using (var escritor = new StreamWriter(_archivoCopia))
                {
                    while (!lector.EndOfStream)
                    {
                        string lineaLeida = lector.ReadLine();
                        Triangulo triangulo = ConstruirTriangulo(lineaLeida);
                        if (triangulo.GetLado1() == triViejo.GetLado1() &&
                            triangulo.GetLado2() == triViejo.GetLado2() &&
                            triangulo.GetLado3() == triViejo.GetLado3() &&
                            triangulo.TipoDeBorde.GetHashCode() == triViejo.TipoDeBorde.GetHashCode() &&
                            triangulo.ColorRelleno.GetHashCode() == triViejo.ColorRelleno.GetHashCode())
                        {
                            lineaLeida = ConstruirLinea(trianguloEditar);
                            escritor.WriteLine(lineaLeida);
                        }
                        else
                        {
                            escritor.WriteLine(lineaLeida);

                        }
                    }
                }
            }
            File.Delete(_archivo);
            File.Move(_archivoCopia, _archivo);
        }
        private Triangulo ConstruirTriangulo(string? lineaLeida)
        {
            var campos = lineaLeida.Split('|');
            int lado1 = int.Parse(campos[0]);
            int lado2 = int.Parse(campos[1]);
            int lado3 = int.Parse(campos[2]);
            TipoDeBorde borde = (TipoDeBorde)int.Parse(campos[3]);
            ColorRelleno color = (ColorRelleno)Enum.Parse(typeof(ColorRelleno), campos[4]);
            Triangulo r = new Triangulo(lado1, lado2, lado3, borde, color);

            return r;
        }
        public void Agregar(Triangulo triangulo)
        {
            using (var escritor = new StreamWriter(_archivo, true))
            {
                string lineaEscribir = ConstruirLinea(triangulo);
                escritor.WriteLine(lineaEscribir);
            }
            listaTriang.Add(triangulo);
        }

        private string ConstruirLinea(Triangulo triangulo)
        {
            return
                $"{triangulo.GetLado1()}|" +
                $"{triangulo.GetLado2()}|" +
                $"{triangulo.GetLado3()}|" +
                $"{triangulo.TipoDeBorde.GetHashCode()}|" +
                $"{triangulo.ColorRelleno.GetHashCode()}";
        }
        public int GetCantidad(int? valorFiltro = 0)
        {
            if (valorFiltro > 0)
            {
                return listaTriang.Count(c => c.Lado1 > valorFiltro);
            }
            return listaTriang.Count();
        }
        public void Borrar(Triangulo trianguloBorrar)
        {
            using (var lector = new StreamReader(_archivo))
            {
                using (var escritor = new StreamWriter(_archivoCopia))
                {
                    while (!lector.EndOfStream)
                    {
                        string lineaLeida = lector.ReadLine();
                        Triangulo trianguloLeido = ConstruirTriangulo(lineaLeida);
                        if (trianguloBorrar.GetLado1() != trianguloLeido.GetLado1())
                        {
                            escritor.WriteLine(lineaLeida);
                        }
                    }
                }
            }
            File.Delete(_archivo);
            File.Move(_archivoCopia, _archivo);
            listaTriang.Remove(trianguloBorrar);
        }
        public List<Triangulo> GetLista()
        {
            LeerDatos();
            return listaTriang;
        }

        public List<Triangulo> Filtrar(int valorFiltro)
        {
            return listaTriang.Where(l => l.ColorRelleno.GetHashCode() == valorFiltro).ToList();
        }


        public bool Existe(Triangulo triangulo)
        {
            listaTriang.Clear();
            LeerDatos();
            bool existe = false;
            foreach (var itemTriangulo in listaTriang)
            {
                if (itemTriangulo.GetLado1() == triangulo.GetLado1() &&
                    itemTriangulo.GetLado2() == triangulo.GetLado2() &&
                    itemTriangulo.GetLado3() == triangulo.GetLado3() &&
                    itemTriangulo.TipoDeBorde == triangulo.TipoDeBorde &&
                    triangulo.ColorRelleno == triangulo.ColorRelleno)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

    