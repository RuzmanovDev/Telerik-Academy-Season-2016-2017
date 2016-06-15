function solve(args) {
    var cars = args;
    var carsLength = cars.length;

    for (var i = 0; i < carsLength; i++) {
        var currentCar = cars[i].split(' ');
        var car = currentCar[0];
        var fuelType = currentCar[1];
        var route = +currentCar[2];
        var luggage = +currentCar[3];

        var fuelConsumption = 10;
        if (fuelType === 'gas') {
            fuelConsumption *= 1.2;
        } else if (fuelType === 'diesel') {
            fuelConsumption *= 0.8;
        }

        fuelConsumption += luggage * 0.01;

        var totalConsumption = 0;
        if (route == 1) {
            totalConsumption = fuelConsumption + 0.1 * fuelConsumption;
            totalConsumption += 0.1 * (0.3 * totalConsumption);
        } else {
            totalConsumption = 0.95 * fuelConsumption;
            totalConsumption += 0.30 * (0.3 * totalConsumption);
        }
        totalConsumption = Math.round(totalConsumption);
        console.log(car + ' ' + fuelType + ' ' + route + ' ' + totalConsumption);
    }

}

var test = ['BMW petrol 1 320.5',
    'Golf petrol 2 150.75',
    'Lada gas 1 202',
    'Mercedes diesel 2 312.54'];

solve(test);
