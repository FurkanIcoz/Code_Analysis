#include <iostream>

using namespace std;

int main() {

	int sayi;
	cin >> sayi;

	int ilk_sayi = 0;
	int ikinci_sayi = 1;

	int sonuc = 1;

	while (sayi>0) {
		sonuc = sonuc * sayi;
		sayi--;
	}
	cout << sonuc;
	cout << endl;
	return 0;
	
}