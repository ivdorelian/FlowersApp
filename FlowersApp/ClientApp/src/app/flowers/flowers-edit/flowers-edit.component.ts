import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FlowersService } from '../flowers.service';
import { Flower, FlowerUpkeepDifficulty } from '../flowers.models';

@Component({
    selector: 'app-flowers-edit',
    templateUrl: './flowers-edit.component.html',
    styleUrls: ['./flowers-edit.component.css']
})
export class FlowersEditComponent implements OnInit {

    private routerLink: string = '../list';

    private flowerID: number;

    private isEdit: boolean = false;

    public formGroup: FormGroup;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private flowersService: FlowersService,
        private formBuilder: FormBuilder) { }

    ngOnInit() {

        this.flowerID = parseInt(this.route.snapshot.params['id']);

        if (this.flowerID) {
            this.routerLink = '../../list';

            this.flowersService.getFlower(this.flowerID).subscribe(res => {
                this.initForm(res);
                this.isEdit = true;
            });
        }
        else {
            this.initForm(<Flower>{});
        }
    }

    save() {
        Object.keys(this.formGroup.controls).forEach(control => {
            this.formGroup.get(control).markAsTouched();
        });

        if (this.formGroup.valid) {
            let flower = this.formGroup.value as Flower;
            flower.flowerUpkeepDifficulty = FlowerUpkeepDifficulty.Easy;

            if (this.isEdit) {
                flower.id = this.flowerID;

                this.flowersService.modifyFlower(flower).subscribe(res => {
                    this.router.navigate(['/flowers']);
                });
            } else {

                this.flowersService.saveFlower(flower).subscribe(res => {
                    this.router.navigate(['/flowers']);
                });
            }
        }
    }

    initForm(flower: Flower) {
        this.formGroup = this.formBuilder.group({
            name: [flower.name, Validators.required],
            description: [flower.description, Validators.required],
            marketPrice: [flower.marketPrice, Validators.required],
            dateAdded: [flower.dateAdded, [Validators.required]]
        });
    }

}
