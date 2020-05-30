import { Component, OnInit, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-flower-details',
  templateUrl: './flower-details.component.html',
  styleUrls: ['./flower-details.component.css']
})
export class FlowerDetailsComponent implements OnInit {

    private flower: FlowerWithDetails;

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        private route: ActivatedRoute) {

    }

    loadFlower(flowerId: string) {
        this.http.get<FlowerWithDetails>(this.baseUrl + 'api/Flowers/' + flowerId).subscribe(result => {
            this.flower = result;
            console.log(this.flower);
        }, error => console.error(error));
    }


    ngOnInit() {
        this.route.paramMap.subscribe(params => {
            this.loadFlower(params.get('flowerId'));
        });
    }
}

interface Comment {
    content: string,
    author: string
}

interface FlowerWithDetails {
    dateAdded: Date;
    name: string;
    description: string;
    marketPrice: number;
    flowerUpkeepDifficulty: string;
    comments: Comment[];
}
