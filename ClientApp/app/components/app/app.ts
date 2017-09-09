import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'Aurelia';
        config.map([{
            route: ['', 'home'],
            name: 'home',
            settings: { icon: 'home' },
            moduleId: PLATFORM.moduleName('../home/home'),
            nav: true,
            title: 'Home'
        }, {
            route: 'passport-mzr-validator',
            name: 'passportmzrvalidator',
            settings: { icon: 'th-list' },
            moduleId: PLATFORM.moduleName('../passport-mzr-validator/passport-mzr-validator'),
            nav: true,
            title: 'Passport MZR Validator'
        }]);

        this.router = router;
    }
}
