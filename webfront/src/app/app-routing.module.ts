import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSafetyDocumentComponent } from './add-safety-document/add-safety-document.component';
import { AddWorkingPlanComponent } from './add-working-plan/add-working-plan.component';
import { AddSwitchingPlanComponent } from './add-switching-plan/add-switching-plan.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { SafetyDocumentViewComponent } from './safety-document-view/safety-document-view.component';
import { IncidentsViewComponent } from './incidents-view/incidents-view.component';
import { AddIncidentComponent } from './add-incident/add-incident.component';
import { ViewWorkingPlanComponent } from './view-working-plan/view-working-plan.component';
import { ViewSwitchingPlanComponent } from './view-switching-plan/view-switching-plan.component';
import { AddConsumerComponent } from './add-consumer/add-consumer.component';





const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'add-safety-document', component: AddSafetyDocumentComponent },
  { path: 'view-safety-document', component: SafetyDocumentViewComponent },
  { path: 'add-working-plan', component: AddWorkingPlanComponent },
  { path: 'view-working-plan', component: ViewWorkingPlanComponent },
  { path: 'add-switchinng-plan', component: AddSwitchingPlanComponent },
  { path: 'incidents', component: IncidentsViewComponent },
  { path: 'add-incidents', component: AddIncidentComponent },
  { path: 'view-switching-plans', component: ViewSwitchingPlanComponent },
  { path: 'add-consumer', component: AddConsumerComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
