import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSafetyDocumentComponent } from './add-safety-document/add-safety-document.component';
import { AddWorkingPlanComponent } from './add-working-plan/add-working-plan.component';
import { AddSwitchingPlanComponent } from './add-switching-plan/add-switching-plan.component';
import { ViewSwitchingPlanComponent } from './view-switching-plan/view-switching-plan.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { SafetyDocumentViewComponent } from './safety-document-view/safety-document-view.component';
import { IncidentsViewComponent } from './incidents-view/incidents-view.component';
import { AddIncidentComponent } from './add-incident/add-incident.component';
import { ViewWorkingPlanComponent } from './view-working-plan/view-working-plan.component';
import { AddConsumerComponent } from './add-consumer/add-consumer.component';
import { AddCrewComponent} from './add-crew/add-crew.component';
import {ViewCrewComponent} from './view-crew/view-crew.component';
import {HomeComponent} from './home/home.component';
import {EditUserComponent} from './edit-user/edit-user.component';
import {DashboardComponent} from './dashboard/dashboard.component';
import {UserVerificationComponent} from './user-verification/user-verification.component';
import {AddDeviceComponent} from './add-device/add-device.component';
import {ViewDevicesComponent} from './view-devices/view-devices.component';
import {ViewConsumersComponent} from './view-consumers/view-consumers.component';
import {ViewCallsComponent} from './view-calls/view-calls.component';
import {AddCallComponent} from './add-call/add-call.component';
import {ChangePasswordComponent} from './change-password/change-password.component';
import {NotificationsComponent} from './notifications/notifications.component';
import {ViewWorkrequestComponent} from './view-workrequest/view-workrequest.component';
import {AddWorkRequestComponent} from './add-work-request/add-work-request.component';
import { AddCrewMemberComponent } from './add-crew-member/add-crew-member.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'add-safety-document', component: AddSafetyDocumentComponent },
  { path: 'view-safety-document', component: SafetyDocumentViewComponent },
  { path: 'add-working-plan', component: AddWorkingPlanComponent },
  { path: 'view-working-plan', component: ViewWorkingPlanComponent },
  { path: 'add-switching-plan', component: AddSwitchingPlanComponent },
  { path: 'view-switching-plan', component: ViewSwitchingPlanComponent },
  { path: 'incidents', component: IncidentsViewComponent },
  { path: 'add-incidents', component: AddIncidentComponent },
  { path: 'view-switching-plans', component: ViewSwitchingPlanComponent },
  { path: 'add-consumer', component: AddConsumerComponent },
  { path: 'add-crew', component: AddCrewComponent},
  { path: 'crews', component: ViewCrewComponent },
  { path: 'user-edit', component: EditUserComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'user-verification', component: UserVerificationComponent },
  { path: 'add-device', component: AddDeviceComponent },
  { path: 'devices', component: ViewDevicesComponent },
  { path: 'consumers', component: ViewConsumersComponent },
  { path: 'calls', component: ViewCallsComponent },
  { path: 'add-call', component: AddCallComponent },
  { path: 'settings', component: ChangePasswordComponent },
  { path: 'notifications', component: NotificationsComponent },
  { path: 'work-requests', component: ViewWorkrequestComponent },
  { path: 'add-work-requests', component: AddWorkRequestComponent },
  { path: 'add-crew-member', component: AddCrewMemberComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
