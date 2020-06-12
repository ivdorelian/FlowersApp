import { Component, OnInit } from '@angular/core';

import { Flower } from '../flowers.models';
import { FlowersService } from '../flowers.service';

@Component({
    selector: 'app-flowers-list',
    templateUrl: './flowers-list.component.html',
    styleUrls: ['./flowers-list.component.css']
})
export class FlowersListComponent implements OnInit {

    public displayedColumns: string[] = ['name', 'description', 'marketPrice', 'numberOfComments', 'action'];
    public flowers: Flower[];

    constructor(private flowersService: FlowersService) {
    }

    ngOnInit() {
        this.loadFlowers();
    }

    loadFlowers() {
        this.flowersService.listFlowers().subscribe(res => {
            this.flowers = res;
        });
    }

    deleteFlower(flower: Flower) {
        this.flowersService.deleteFlower(flower.id).subscribe(x => {
            this.loadFlowers();
        });
    }

}
