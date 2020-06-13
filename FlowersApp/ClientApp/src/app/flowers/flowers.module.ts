import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CoreModule } from '../core/core.module';
import { AngularMaterialModule } from '../shared/angular-material.module';

import { FlowersRoutingModule } from './flowers-routing.module';

import { FlowersService } from './flowers.service';

@NgModule({
    declarations: [FlowersRoutingModule.routedComponents],
    imports: [
        CommonModule,
        FlowersRoutingModule,
        AngularMaterialModule,
        CoreModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [FlowersService],
})
export class FlowersModule { }
