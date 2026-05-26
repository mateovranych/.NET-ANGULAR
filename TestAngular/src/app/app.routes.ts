import { Routes } from '@angular/router';
import { DashboardB } from './dashboard-b/dashboard-b';

export const routes: Routes = [


    {
        path: '',
        loadComponent: () =>
            import('./home/home').then(m => m.Home)
    },

    {
        path: 'home',
        loadComponent: () =>
            import('./home/home').then(m => m.Home)
    },

    {
        path: 'dashboardA',
        loadComponent: () =>
            import('./dashboard-a/dashboard-a').then(m => m.DashboardA)

    },

    {
        path: 'dashboardB',
        loadComponent: () =>
            import('./dashboard-b/dashboard-b').then(m => m.DashboardB)
    },

    {
        path: 'dashboardC',
        loadComponent: () => 
            import('./dashboard-c/dashboard-c').then(m => m.DashboardC)
    }



];
