import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-fetch-data',
    templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public flowers: Flower[];

    public name: string = "test";

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        this.loadFlowers();
    }


    loadFlowers() {
        this.http.get<Flower[]>(this.baseUrl + 'api/Flowers').subscribe(result => {
            this.flowers = result;
            console.log(this.flowers);
        }, error => console.error(error));
    }

    delete(flowerId: string) {
        if (confirm('Are you sure you want to delete the flower with id ' + flowerId + '?')) {
            this.http.delete(this.baseUrl + 'api/Flowers/' + flowerId)
                .subscribe
                (
                    result => {
                        alert('Flower successfully deleted!');
                        this.loadFlowers();
                    },
                    error => alert('Cannot delete flower - maybe it has comments?')
                )
        }
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
            this.loadFlowers();
        },
        error => {    
            if (error.status == 400) {
                console.log(error.error.errors)
            }
        });
    }
}

interface Flower {
    id: number;
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
