import { Component, OnInit, Input } from '@angular/core';
import { Tuner } from '../../tuner.model';

@Component({
  selector: 'tuner-item',
  templateUrl: './tuner-item.component.html'
})
export class TunerItemComponent {
  @Input() tuner: Tuner [] = [];

  constructor() { }
  ngOnInIt() {

  }
}
