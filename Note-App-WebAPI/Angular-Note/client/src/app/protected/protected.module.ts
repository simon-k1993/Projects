import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProtectedRoutingModule } from './protected-routing.module';
import { ProtectedComponent } from './protected/protected.component'; 

@NgModule({
  declarations: [
    ProtectedComponent,
  ],
  imports: [
    CommonModule,
    ProtectedRoutingModule 
  ]
})
export class ProtectedModule { }
