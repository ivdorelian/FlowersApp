import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Flower } from './flowers.models';
import { ApplicationService } from '../core/services/application.service';

@Injectable()
export class FlowersService {

    constructor(
        private http: HttpClient,
        private applicationService: ApplicationService) { }

    getFlower(id: number) {
        return this.http.get<Flower>(`${this.applicationService.baseUrl}api/Flowers/${id}`);
    }

    listFlowers() {
        return this.http.get<Flower[]>(`${this.applicationService.baseUrl}api/Flowers`);
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
