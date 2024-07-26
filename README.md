# ING zadanie rekrutacyjne

Aplikacja posiada jeden endpoint GET, z którego można skorzystać przez Swaggera, który otworzy się automatycznie po starcie aplikacji.

Do obsługi błędów zastosowano middleware, które przechwytuje wszystkie błędy, które mogą wystąpić w trakcie zapytania.

Endpoint jest wywoływany dla waluty euro i ostatnich 20 dni, ale jest przystosowany do łatwej konfiguracji dla innych walut i zakresu dat.

Wszystkie logi aplikacji są zapisywane do konsoli oraz pliku.
