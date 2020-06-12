import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AngularMaterialModule } from './shared/angular-material.module';

import { CoreModule } from './core/core.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { FlowerDetailsComponent } from './flower-details/flower-details.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
    { path: 'register', component: RegistrationComponent },
    { path: 'login', component: LoginComponent },

    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'counter', component: CounterComponent },
    {
        path: 'fetch-data',
        component: FetchDataComponent,
    },
    {
        path: 'fetch-data/:flowerId',
        component: FlowerDetailsComponent,
    },
    { path: 'my-route', component: CounterComponent },
];


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent,
        RegistrationComponent,
        LoginComponent,
        FlowerDetailsComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        AngularMaterialModule,
        RouterModule.forRoot(routes),
        BrowserAnimationsModule,
        CoreModule
    ],
    exports: [AngularMaterialModule, CoreModule],
    providers: [],
    bootstrap: [AppComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
