export interface Flower {
    id: number;
    dateAdded: Date;
    name: string;
    description: string;
    marketPrice: number;
    flowerUpkeepDifficulty: FlowerUpkeepDifficulty;
}

export enum FlowerUpkeepDifficulty {
    Easy = 0,
    Medium = 1,
    Hard = 2
}
