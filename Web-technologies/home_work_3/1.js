const temperatureCelsius = Number.parseFloat(prompt("Введите температуру в градусах Цельсия: "));
const temperatureFahrenheit =  ConvertCelsiusToFahrenheit(temperatureCelsius);

alert(`${temperatureCelsius} градусов Цельсия соответсвует ${temperatureFahrenheit.toFixed(1)} градусов по Фаренгейту `);

function ConvertCelsiusToFahrenheit(temperature){
    return (9 / 5) * temperature + 32;
}