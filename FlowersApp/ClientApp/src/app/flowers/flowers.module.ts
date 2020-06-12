import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CoreModule } from '../core/core.module';
import { AngularMaterialModule } from '../shared/angular-material.module';

import { FlowersService } from './flowers.service';

import { FlowersRoutingModule } from './flowers-routing.module';

@NgModule({
    declarations: [FlowersRoutingModule.routedComponents],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        CoreModule,
        AngularMaterialModule,
        ReactiveFormsModule,
        FlowersRoutingModule
    ],
    providers: [FlowersService]
})
export class FlowersModule { }
