import { Component, OnInit } from '@angular/core';
import { Tuner } from '../tuner.model';
import { TunerService } from '../tuner.service';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'tuner-edit',
  templateUrl: './edit.component.html'
})
export class TunerEditComponent implements OnInit {
  tuner: Tuner;
  editMode = false;
  originalTuner: Tuner;
  id: string;

  constructor(private tunerService: TunerService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params
      .subscribe(
        (params: Params) => {
          this.id = params['id'];
          if (this.id === null || this.id === undefined) {
            this.editMode = false;
            return;
          }

          this.originalTuner = this.tunerService.getTuner(this.id);
          if (this.originalTuner === null || this.originalTuner === undefined) {
            return;
          }

          this.editMode = true;
          this.tuner = JSON.parse(JSON.stringify(this.originalTuner));

        }
      );
  }

  onSubmit(form: NgForm) {
    const value = form.value;
    const newTuner = new Tuner(value.Id, value.Manufacturer, value.Model, value.Submodel, value.Color, value.Picture, value.Vin, value.Year, null);
    if (this.editMode === true) {
      this.tunerService.updateTuner(this.originalTuner, newTuner);
    } else {
      this.tunerService.addTuner(newTuner);
    }
    this.router.navigate(['/tuner']);
  }

  onCancel() {
    this.router.navigate(['/tuner']);
  }

  isInvalidTuner(newTuner: Tuner) {
    if (!newTuner) {
      return true;
    }
    if (newTuner.Id === this.tuner.Id) {
      return true;
    }
    return false;
  }
}
