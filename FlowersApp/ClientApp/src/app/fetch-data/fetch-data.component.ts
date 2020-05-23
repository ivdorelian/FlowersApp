import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-fetch-data',
    templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public forecasts: WeatherForecast[];

    public flowers: Flower[];

    public name: string = "test";

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

        http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
            this.forecasts = result;
        }, error => console.error(error));

        this.loadFlowes();
    }


    loadFlowes() {
        this.http.get<Flower[]>(this.baseUrl + 'api/Flowers').subscribe(result => {
            this.flowers = result;

            console.log(this.flowers);

        }, error => console.error(error));
    }

    submit() {

        var flower: Flower = <Flower>{};
        flower.name = this.name;
        flower.description = this.name;
        flower.dateAdded = new Date();
        flower.flowerUpkeepDifficulty = FlowerUpkeepDifficulty.Easy;
        flower.marketPrice = 5;

        this.http.post(this.baseUrl + 'api/Flowers', flower).subscribe(result => {

            console.log('success!');

            this.loadFlowes();
        },
            error => {

                if (error.status == 400) {
                    console.log(error.error.errors)
                }
            });
    }
}

interface WeatherForecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

interface Flower {
    dateAdded: Date;
    name: string;
    description: string;
    marketPrice: number;
    flowerUpkeepDifficulty: FlowerUpkeepDifficulty;
}

enum FlowerUpkeepDifficulty {
    Easy = 0,
    Medium = 1,
    Hard = 2
}
