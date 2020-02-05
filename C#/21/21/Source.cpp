#include <iostream>
#include <cmath>
using namespace std;
int main()
{
	int type, x, y, z, p, r;
	double S, P;
	const double pi = 3.1415;
	cout << "Vvedite tip figury (1 - priamougolnik, 2 - krug, 3 - treugolnik): ";
	cin >> type;
	switch (type)
	{
	case 1:
	{
		cout << "Vvedite x: ";
		cin >> x;
		cout << "Vvedite y: ";
		cin >> y;
		S = x * y;
		cout << "площадь прямоугольника " << S << endl;
		P = x + x + y + y;
		cout <<  "периметр прямоугольника" << P << endl;
		break;
	}
	case 2:
	{
		cout << "Vvedite r: ";
		cin >> r;
		S = r * pi * r;
		cout << "площадь круга " << S << endl;
		P = 2 * pi * r;
		cout <<  "периметр круга " << P << endl;
		break;
	}
	case 3:
	{
		cout << "Vvedite x: ";
		cin >> x;
		cout << "Vvedite y: ";
		cin >> y;
		cout << "Vvedite z: ";
		cin >> z;
		if (x + y > z && b + c > a && a + c > b)
		{
			double p = (x + y + z) / 2;
			S = sqrt(p * (p - x) * (p - y) * (p - z));
			cout << "площадь треугольника " << S << endl;
			P = x + y + z;
			cout << "периметр треугольника" << P << endl;
		}
		else
			cout << "Треугольник не существует" << endl;
		break;
	}
default:
	cout << "Vvedite chislo ot 1 do 4" << endl;
}
return 0;
}