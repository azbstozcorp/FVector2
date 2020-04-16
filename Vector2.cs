    public class Vector2 {
        public double X {
            get => _x; set {
                _x = value;
                RecalculateLength();
            }
        }
        public double Y {
            get => _y; set {
                _y = value;
                RecalculateLength();
            }
        }
        public double Length => _length;
        public double LengthSquared => Length * Length;
        double _x, _y, _length;

        public Vector2 Normalized() => new Vector2(X / Length, Y / Length);

        public Vector2() { }
        public Vector2(double x, double y) {
            // Setting the X and Y properties would square root twice, this way only one square root is done
            _x = x;
            _y = y;
            RecalculateLength(); 
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.X + b.X, a.Y + b.Y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.X - b.X, a.Y - b.Y);

        public static double Distance(Vector2 a, Vector2 b) => Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));

        public static double DotProduct(Vector2 a, Vector2 b) => (a.X * b.X) + (a.Y * b.Y);

        public static Vector2 ProjectOnto(Vector2 from, Vector2 onto) {
            Vector2 result = new Vector2();

            double dot = DotProduct(from, onto);

            result.X = dot / onto.LengthSquared * onto.X;
            result.Y = dot / onto.LengthSquared * onto.Y;

            return result;
        }

        void RecalculateLength() {
            _length = Sqrt(X * X + Y * Y);
        }
    }
