import { Flower } from "./flowers.models";

export interface PaginatedFlowers {
    currentPage: number; 
    totalItems: number;
    itemsPerPage: number;
    totalPages: number;
    items: Flower[];
}
