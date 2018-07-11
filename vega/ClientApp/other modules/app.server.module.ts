import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from '../app/./app.module';
import { AppComponent } from '../app/./components/app/app.component';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        ServerModule,
        AppModuleShared
    ]
})
export class AppModule {
}
