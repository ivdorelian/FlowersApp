import { Component, OnInit } from '@angular/core';

import { Flower } from '../flowers.models';
import { FlowersService } from '../flowers.service';
import { PaginatedFlowers } from '../paginatedFlowers.models';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-flowers-list',
  templateUrl: './flowers-list.component.html',
  styleUrls: ['./flowers-list.component.css']
})
export class FlowersListComponent implements OnInit {

    public displayedColumns: string[] = ['name', 'description', 'marketPrice', 'numberOfComments', 'action'];
    public flowers: PaginatedFlowers;
    public pageEvent: PageEvent;

    constructor(private flowersService: FlowersService) {
    }

    ngOnInit() {
        this.loadFlowers(null);
    }

    loadFlowers(event?: PageEvent) {
        this.flowers = null;
        this.flowersService.listFlowers(event).subscribe(res => {
            this.flowers = res;
        });
    }

    deleteFlower(flower: Flower) {
        this.flowersService.deleteFlower(flower.id).subscribe(x => {
            this.loadFlowers();
        });
    }

}
