import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Flower } from './flowers.models';
import { ApplicationService } from '../core/services/application.service';
import { PaginatedFlowers } from './paginatedFlowers.models';
import { PageEvent } from '@angular/material/paginator';

@Injectable()
export class FlowersService {

    constructor(
        private http: HttpClient,
        private applicationService: ApplicationService) { }

    getFlower(id: number) {
        return this.http.get<Flower>(`${this.applicationService.baseUrl}api/Flowers/${id}`);
    }

    listFlowers(event?: PageEvent) {

        let pageIndex = event ? event.pageIndex + "" : "0";
        let itemsPerPage = event ? event.pageSize + "" : "25";
        console.log(event);
        let params = new HttpParams().set("page", pageIndex).set("itemsPerPage", itemsPerPage); //Create new HttpParams
        return this.http.get<PaginatedFlowers>(`${this.applicationService.baseUrl}api/Flowers`, { params: params });
    }

    saveFlower(flower: Flower) {
        return this.http.post(`${this.applicationService.baseUrl}api/Flowers`, flower);
    }

    modifyFlower(flower: Flower) {
        return this.http.put(`${this.applicationService.baseUrl}api/Flowers/${flower.id}`, flower);
    }

    deleteFlower(id: number) {
        return this.http.delete<any>(`${this.applicationService.baseUrl}api/Flowers/${id}`);
    }
}
