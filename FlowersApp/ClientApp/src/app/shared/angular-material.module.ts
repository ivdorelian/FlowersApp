import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        MatSliderModule,
        MatSlideToggleModule,
        MatTableModule
    ],
    exports: [
        MatSliderModule,
        MatSlideToggleModule,
        MatTableModule,
        MatCardModule
    ]
})

export class AngularMaterialModule { }
