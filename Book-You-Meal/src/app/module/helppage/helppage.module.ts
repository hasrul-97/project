import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule} from '@angular/forms';

import { HelppageRoutingModule } from './helppage-routing.module';
import { HelpComponent } from './help/help.component';


@NgModule({
  declarations: [HelpComponent],
  imports: [
    CommonModule,
    HelppageRoutingModule,
    FormsModule
  ]
})
export class HelppageModule { }
