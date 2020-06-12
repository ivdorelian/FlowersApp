import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FlowersComponent } from './flowers.component';
import { FlowersListComponent } from './flowers-list/flowers-list.component';
import { FlowersEditComponent } from './flowers-edit/flowers-edit.component';

const routes: Routes = [
    {
        path: '', component: FlowersComponent, data: { navArea: 'periodic-elements' },
        children: [
            { path: '', redirectTo: 'list', pathMatch: 'full' },
            { path: 'list', component: FlowersListComponent },
            { path: 'edit/:id', component: FlowersEditComponent },
            { path: 'edit', component: FlowersEditComponent },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class FlowersRoutingModule {
    static routedComponents = [FlowersComponent, FlowersListComponent, FlowersEditComponent];
}
