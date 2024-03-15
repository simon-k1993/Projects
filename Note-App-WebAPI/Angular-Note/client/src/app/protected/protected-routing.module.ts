import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { ProtectedComponent } from './protected/protected.component'; 

const protectedRoutes: Routes = [
  { path: '', component: ProtectedComponent }

];

@NgModule({
  imports: [RouterModule.forChild(protectedRoutes)],
  exports: [RouterModule]
})
export class ProtectedRoutingModule { }
