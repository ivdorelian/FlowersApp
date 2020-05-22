import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
})
export class HomeComponent {

    name: string = "test"


    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
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

        },
            error => {

                if (error.status == 400) {
                    console.log(error.error.errors)
                }
            });
    }
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
