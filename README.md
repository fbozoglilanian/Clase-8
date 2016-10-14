#Angular

##¿Qué es angular?

La meta de angular es traer las herramientas y capacidades que han estado disponibles para el desarrollo de back-end al cliente web, facilitando el desarrollo, test y mantenimiento de aplicaciones web complejas y ricas en contenido.

Angular funciona permitiéndonos extender HTML, expresando funcionalidad a través de elementos, atributos, clases y comentarios. 

El estilo de desarrollo de Angular se deriva del uso del patrón MVC, aunque suelen referirse a él como MV*, dada la cantidad de variaciones al patrón a las que se adhieren cuanod se desarrolla. 

##¿Para qué sirve?

No es la solución para cada problema, y hay que saber cuando utilizarlo o buscar una alternativa.
Dado lo que angular provee, significa que tiene mucho trabajo para hacer cada vez que un documento HTML al que se le aplicó Angular se carga (compilar elementos hl, evaluar bindings, ejecutar directivas, etc). Este tipo de trabajo lleva tiempo para perforar, y ese tiempo depende de la complejidad del documento HTML, el código JS asociado y -más critico aún - la calidad del navegador y la capacidad de procesamiento del dispositivo.
En una máquina nueva con las últimas actualizaciones de Browsers no debería notarse ningún lag, pero en viejos smartphones, el setup puede llevar mucho tiempo. El objetivo, entonces, es realizar el setup tan infrecuentemente como sea posible, y entregar la mayor cantidad de  la app al usuario cuando se hace. 

##Round-Trip vs SPA

Durante mucho tiempo, las aplicaciones web se pensaban como Round- trip: El browser hace el request inicial del documento HTML al servidor, las interacciones del Usuario hacían que el browser solicitara y recibiera un documento HTML completamente nuevo cada vez. En este tipo de aplicación, el browser es solo una especie de renderer de HTML, y toda la lógica de la aplicación va del lado del servidor. El browser realiza una serie de Requests HTTP sin estado que el server maneja generando documentos html dinámicamente.
Este modelo, si bien se sigue usando hoy en día, tiene algunas desventajas: El usuario debe esperar mientras el siguiente documento HTML se genera, requieren mayor infraestructura del lado del servidor para procesar todos los requests y manejar el estado de la aplicación, y requieren más ancho de banda, ya que cada documento HTML debe estar autocontenido.

SPAs toman un enfoque diferente. Un HTML inicial se envía al browser, pero las interacciones del usuario generan requests a través de ajax para pequeños fragmentos de HTML o datos que se inserta en el conjunto de elementos que se muestra al usuario. El documento HTML inicial nunca se recarga, y el usuario puede seguir intercalando con el html existente mientras las requests ajax terminan de ejecutarse asincrónicamente.

AngularJS logra sus mejores resultados cuando la aplicación a desarrollar se acerca al modelo de Sigle-page. No quiere decir que no se pueda usar para round-trip, pero hay otras herramientas, como Jquery, que lo hacen mejor.
 
##El problema que Angular quiere resolver

Complejidad de manejar el DOM  y la lógica de una aplicación manualmente.

##MV*

Este patrón por primera vez apareció en el mundo web en el framework Ruby on Rails. En los últimos años, se lo ha utilizado como una manera de manejar el aumento en la richness y complejidad de client-side web también, en donde aparece Angular.
La clave es cumplir con la separaci´n de responsabilidades, en el que el modelo de una aplicación esta desacoplado de la lógica de negocio y de presentación. En front end, esto significa separar la data, la lógica que opera sobre esos datos y los elementos html usados para mostrarlos.
En Angular, sin embargo, este patrón es llevado un poco más allá a lo que se conoce como MV* (Model - view- whatever). 
Por un lado tenemos el modelo ```(var firstName = ‘Tony’)``` y por otro la view ```(<h1>Tony</h1>)```. Y Angular permite que estos dos estén atados entre si. Puede ser mediante controllers, View Models, o lo que sea. Nosotros vamos a basarnos en el MVC.

###Models
Contienen los datos con los que los usuarios interactúan. hay dos tipos: 
    - View Models: representan datos que se pasan del controller a la view.
    - Domain Models: representan los datos en el dominio de negocio, junto a operaciones, transformaciones y reglas para crear ordenar y manipular esa data, No se incluye lógica en el model.

El Modelo en una aplicación debería contener datos del dominio, y la lógica para crear, administrar, y modificar esos datos del dominio (incluso si eso implica ejecutar lógica remota, por ej: a través de Web Services -una API-).

El Modelo entonces debería proveer una API limpia que expone datos y operaciones, pero NUNCA debería:

1. exponer cómo el modelo obtiene/administra sus datos (en otras palabras, detalles de cómo s guarda el estado, o cómo se accede al Web service no deberían ser expuestos a los controllers o a las views).
2. contener lógica que transforma el el estado del modelo en base a la interacción del usuario (eso es responsabilidad del controller)
3. contener lógica que se encarga de mostrar los datos al usuario (eso es responsabilidad de la view)

Es importante recordar que la idea de MVC, no es separar por un lado lógica y por otro lado datos. El objetivo del Patrón MVC, es el de dividir una aplicación en 3 áres funcionales, donde cada una puede contener tanto lógica como datos. El objetivo no es eliminar la lógica de los modelos, si no que más bien asegurar que el modelo solo tiene la lógica para crear y administrar los datos.
 
###Views:
Las vistas de AngularJS se definen usando elementos HTML mejorados que generan html usando los data bindings y las directivas. Son estas directivas (elementos HTML mejorados que permiten generar html basados en el modelo) las que vuelven las vistas tan flexibles. Las vistas deberían contener:

1.  Lógica y Maquetación requerida para presentar la data al usuario.

###Controllers:
Son el tejido conector de una aplicación Angular, actuando como conductos entre el modelo de datos y las views. Los controllers agregan lógica de dominio (comportamiento) a scopes. 
Un controller debería:

1. Tener la lógica requerida para inicializar el scope.
2. Tener la lógica/comportamiento requerido por la vista para presentar el scope.
3. Tener la lógica/comportamiento requerido para actualizar el scope basado en la interacción con el usuario.

###View Data:

El modelo de dominio no es el único conjunto de datos en una aplicación. Controllers pueden crear view data (view model) para simplificar la definición de las vistas. No es persistente y es creada sintetizando algún aspecto del modelo de dominio o en respuesta a la interacción del usuario. 

##Moduless en Angular

Son el componente de más alto nivel de aplicaciones AngularJS. Si bien es posible construir aplicaciones angular simples sin necesidad de referenciar modulos, esto puede volverse complejo, y terminamos teniendo que reescribir toda la aplicación.
Tienen tres funciones:
    Asociar la aplicación Angular con una región de un documento HTML
    Actuar como portal a algunas funcionalidades clave del framework.
    Ayudar a organizar el código y componentes en una aplicación Angular

Primer App con Web API y Angular. -> No dejar que escriban al mismo tiempo, copiando código, sino que ir explicando mientras se va escribiendo lo que se está haciendo.

Usar http://plnkr.co

ir a angularjs.org/develop download y mostrar el código js. explicar diferencia entre min y no min.
ir a getbootstrap.com Explicar qué es bootstrap y como usarlo.

Pasos para la aplicación:

var myApp = angular.module(‘myApp’, []);
ng-app: angular busca ese módulo para crear la aplicación. y que sea igual al angular.module.

MyApp.controller(‘mainController’, function() {
    
});

y atarlo con 
<div ng-controller=“mainController”>

</div>

Entonces el controller va a controlar lo que pase adentro de ese div.


##Ejercicio Angular

Abrimos la solución de Tresana, y en el proyecto de Tresana.Web.Api, instalar con Nuget packages AngularJS.Core. Esto nos permitirá bajar la última versión de Angular disponible.
Luego, creamos una carpeta Views en el proyecto, y creamos una página index.html dentro de esa carpeta. Con botón derecho, la seleccionamos como Página de Inicio.
La razón para tener el proyecto de angular dentro de la misma aplicación que Web.Api es que nos permitrá correrla en el mismo puerto, evitando errores de CORS. 

Para inicializar la aplicación, nos creamos una carpeta ```app``` dentro de la carpeta Scripts en Web.Api. Creamos un archivo ```app.js```, y en él crearemos una función anónima.

```javascript

(function(){
    'use strict';

})();

```

Esta función se ejecutará automáticamente al hacer el import del archivo.
Llegó el momento de comenzar con Angular. Para ello, debemos llamar al objeto angular, e inicializar un módulo.

```javascript

(function(){
    'use strict';

    angular.module('Tresana', []);

})();

```

Ahora llegó el momento de importar angular y esta aplicación. Para ello, debemos importarlo en el archivo ```index.html```.

```html

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="../Scripts/angular.min.js"></script>
    <script src="../Scripts/app/app.js"></script>
</head>
<body>
    
</body>
</html>

```

Y ahora podemos inicializar la aplicación. Para ello agregaremos lo que se conoce como una directiva: ```ng-app```. Las directivas en angular son componentes que nos permiten generar nuestros propios tags HTML para agregar comportamiento avanzado a nuestras aplicaciones.

La directiva que utilizaremos, ng-app permite inicializar la aplicación angular. Puede incluirse tanto dentro del tag ```body``` como el ```html```, aunque lo haremos en el primero.

```html

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="../Scripts/angular.min.js"></script>
    <script src="../Scripts/app/app.js"></script>
</head>
<body ng-app="Tresana">
    
</body>
</html>

```

Ahora es momento de que nuestra aplicación haga algo. Para ello nos crearemos un controller para manejar la lista de tareas de Tresana. Para este primer ejemplo, no nos comunicaremos con la api. 
Los controllers en Angular, a diferencia de los controllers de Web Api, nos permiten comunicar la vista con los modelos. Para instanciar un controller, debemos acceder al módulo que nos definimos anteriormente, y agregarle un controller. Para estructurar nuestra aplicación, lo haremos agrupando los archivos web en carpetas dependiendo de la funcionalidad.
Por lo tanto, al mismo nivel que la carpeta app, nos creamos otra carpeta que sea tasks. En esta carpeta, nos crearemos un controlador, al que llamaremos tasksController.

```Javascript

(function () {
    'use strict';

    var tresanaApp = angular.module('Tresana');

})();

```

En la sentencia ```var tresanaApp = angular.module('Tresana');``` lo que logramos es obtener el objeto de la aplicación Angular tresana, a la que queremos agregarle un controller. Notemos que en este caso, la sentencia module recbie un sólo parámetro, ya que está buscando obtener el módulo con ese nombre, y no crearlo. 
Para crear el controller, llamamos al método controller del módulo, con el nombre que queremos usar y una función fábrica.

```Javascript

(function () {
    'use strict';

    var tresanaApp = angular.module('Tresana');

     tresanaApp.controller('Tasks.Controller', function() {

    });

})();

```

Ahora, agreguemos datos al controller. Normalmente, esto se hace buscando a una api como la que hicimos anteriormente, pero para comenzar, creemos un objeto JSON con Tareas. En primer lugar, debemos crear una variable ctrl que nos permita guardar el controller como objeto, y a ella le asignaremos las tareas.


```Javascript

(function () {
    'use strict';

    var tresanaApp = angular.module('Tresana');

     tresanaApp.controller('Tasks.Controller', function() {

        var ctrl = this;

          ctrl.tasks = [
            {
                Id: 3,
                Name: "Crear Proyecto Angular",
                Description: "Crear el proyecto Angular dentro del Proyecto de Tresana.Web.Api para enseñar como utlizar la librería",
                Priority: 1,
                StartDate: new Date("2016-05-11T19:00:00"),
                FinishDate: null,
                Estimation: 3,
                Status: "Todo",
                Creator: 1,
                CreationDate: new Date("2016-05-09T22:20:00"),
                DueDate: new Date("2016-05-11T20:30:00")
            },
            {
                Id: 4,
                Name: "Enseñar Angular",
                Description: "Describir para que sirve angular, que problema soluciona y los principales componentes",
                Priority: 2,
                StartDate: new Date("2016-05-11T18:30:00"),
                FinishDate: null,
                Estimation: 1,
                Status: "Todo",
                Creator: 1,
                CreationDate: new Date("2016-05-09T22:30:00"),
                DueDate: new Date("2016-05-11T19:00:00")
            }
        ];

    });

})();

```

Ya tenemos un controller, ahora usémoslo!

Para ello, volvamos al index.html, e incorporemos el controller.

```html

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="../Scripts/angular.min.js"></script>
    <script src="../Scripts/app/app.js"></script>
    <script src="../Scripts/tasks/tasksController.js"></script>
</head>
<body ng-app="Tresana">
    
</body>
</html>

```

Ahora, mostremos el nombre y la descripción de las tareas que tenemos cargadas. Para ello, utilizaremos una nueva directiva: ```ng-controller```. Esta directiva ata un controller a una porción de la vista. Utilizaremos la notación controller as, ya que nos permitirá tener mayor control sobre lo realizado.

```html

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="../Scripts/angular.min.js"></script>
    <script src="../Scripts/app/app.js"></script>
    <script src="../Scripts/tasks/tasksController.js"></script>
</head>
<body ng-app="Tresana">
    <div ng-controller="Tasks.Controller as tasksCtrl">
    
    </div>
</body>
</html>

```

Ahora podemos acceder al array de tareas que nos creamos. Pero en lugar de tener que cargarlas una por una, aprovecharemos otra directiva de angular que nos permite iterar de manera sencilla: ```ng-repeat```.

```html

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="../Scripts/angular.min.js"></script>
    <script src="../Scripts/app/app.js"></script>
    <script src="../Scripts/tasks/tasksController.js"></script>
</head>
<body ng-app="Tresana">
    <div ng-controller="Tasks.Controller as tasksCtrl">
        <div ng-repeat="task in tasksCtrl.tasks">
            <h2>Task Name: {{task.Name}}</h2>
            <p>Description: {{task.Description}}</p>
        </div>
    </div>
</body>
</html>

```
Podemos apreciar que tenemos un tipo particular de texto, entre ```{ }```. Este texto se conoce como interpolación, y permite tomar las variables de los objetos de javascript e intercalarlos en nuestro HTML.
Mostremos también las fechas de creación, de comienzo, y de vencimiento.

```html

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="../Scripts/angular.min.js"></script>
    <script src="../Scripts/app/app.js"></script>
    <script src="../Scripts/tasks/tasksController.js"></script>
</head>
<body ng-app="Tresana">
    <div ng-controller="Tasks.Controller as tasksCtrl">
        <div ng-repeat="task in tasksCtrl.tasks">
            <h2>Task Name: {{task.Name}}</h2>
            <p>Description: {{task.Description}}</p>
            <p>Creation Date: {{task.CreationDate}}</p>
            <p>Start Date: {{task.StartDate}}</p>
            <p>Due Date: {{task.DueDate}}</p>
        </div>
    </div>
</body>
</html>

```

Sin embargo, las fechas se ven feas, no? Para mejorarlo, hagamos una función en nuestro controller.

```Javascript

    tresanaApp.controller('Tasks.Controller', function() {

        var ctrl = this;
        .
        .
        .

        ctrl.printDate = function printDate(date) {
            return date.getDate() + "-" + (date.getMonth() + 1) + "-" + date.getFullYear() + " at " + date.getUTCHours() + ":" + date.getUTCMinutes();
        }
    });        

```

Esta función ahora está disponible para que la utilicemos en el Html.

```html

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="../Scripts/angular.min.js"></script>
    <script src="../Scripts/app/app.js"></script>
    <script src="../Scripts/tasks/tasksController.js"></script>
</head>
<body ng-app="Tresana">
    <div ng-controller="Tasks.Controller as tasksCtrl">
        <div ng-repeat="task in tasksCtrl.tasks">
            <h2>Task Name: {{task.Name}}</h2>
            <p>Description: {{task.Description}}</p>
            <p>Creation Date: {{tasksCtrl.printDate(task.CreationDate)}}</p>
            <p>Start Date: {{tasksCtrl.printDate(task.StartDate)}}</p>
            <p>Due Date: {{tasksCtrl.printDate(task.DueDate)}}</p>
        </div>
    </div>
</body>
</html>

```

Mejor, no?

Pero como podemos hacer para ordenar este array? Agreguemos entonces un filtro.
Los filtros en angular nos permiten manipular los datos de manera sencilla. Empezaremos con un filtro de orderBy


```html

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="../Scripts/angular.min.js"></script>
    <script src="../Scripts/app/app.js"></script>
    <script src="../Scripts/tasks/tasksController.js"></script>
</head>
<body ng-app="Tresana">
    <div ng-controller="Tasks.Controller as tasksCtrl">

        Order by:
        <select ng-model="tasksCtrl.orderBy">
            <option value="StartDate">Start Date</option>
            <option value="CreationDate">Creation Date</option>
        </select>

        <div ng-repeat="task in tasksCtrl.tasks">
            <h2>Task Name: {{task.Name}}</h2>
            <p>Description: {{task.Description}}</p>
            <p>Creation Date: {{tasksCtrl.printDate(task.CreationDate)}}</p>
            <p>Start Date: {{tasksCtrl.printDate(task.StartDate)}}</p>
            <p>Due Date: {{tasksCtrl.printDate(task.DueDate)}}</p>
        </div>
    </div>
</body>
</html>

```

En el tag select, incorporamos la directiva ```ng-model```. Esta directiva nos permite comunicarle a angular que esa variable debe mirarse contstantemente, ya que ante un cambio deberá efectuar algunos cambios en la aplicación. En este caso, agregamos a nuestro controller una variable llamada orderBy, la cual se definirá dependiendo de la opción seleccionada. En las opciones del select, colocamos las propiedades de los elementos según las cuales querremos ordenar. Ahora debemos agregar este filtro al ```ng-repeat```.

```html

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="../Scripts/angular.min.js"></script>
    <script src="../Scripts/app/app.js"></script>
    <script src="../Scripts/tasks/tasksController.js"></script>
</head>
<body ng-app="Tresana">
    <div ng-controller="Tasks.Controller as tasksCtrl">

        Order by:
        <select ng-model="tasksCtrl.orderBy">
            <option value="StartDate">Start Date</option>
            <option value="CreationDate">Creation Date</option>
        </select>

        <div ng-repeat="task in tasksCtrl.tasks | orderBy: tasksCtrl.orderBy">
            <h2>Task Name: {{task.Name}}</h2>
            <p>Description: {{task.Description}}</p>
            <p>Creation Date: {{tasksCtrl.printDate(task.CreationDate)}}</p>
            <p>Start Date: {{tasksCtrl.printDate(task.StartDate)}}</p>
            <p>Due Date: {{tasksCtrl.printDate(task.DueDate)}}</p>
        </div>
    </div>
</body>
</html>

```

Agregando ```|``` le especificamos que estamos llamando a un filtro, luego imponemos que filtro queremos (en este caso ```orderBy```), y le indicamos según qué variable debería hacerse.
Para información detallada de todos los filtros posibles, pueden verla [aquí](https://docs.angularjs.org/api/ng/filter).

Ahora agregaremos un buscador. Este es otro tipo de filtro, llamado filter.

Para ello, agregamos un campo de input, con otro tag de ```ng-model``` para que pueda atarse a angular.

```html

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="../Scripts/angular.min.js"></script>
    <script src="../Scripts/app/app.js"></script>
    <script src="../Scripts/tasks/tasksController.js"></script>
</head>
<body ng-app="Tresana">
    <div ng-controller="Tasks.Controller as tasksCtrl">
        Filter by:
        <input type="text" ng-model="tasksCtrl.filter"/>
        Order by:
        <select ng-model="tasksCtrl.orderBy">
            <option value="StartDate">Start Date</option>
            <option value="CreationDate">Creation Date</option>
        </select>

        <div ng-repeat="task in tasksCtrl.tasks | orderBy: tasksCtrl.orderBy">
            <h2>Task Name: {{task.Name}}</h2>
            <p>Description: {{task.Description}}</p>
            <p>Creation Date: {{tasksCtrl.printDate(task.CreationDate)}}</p>
            <p>Start Date: {{tasksCtrl.printDate(task.StartDate)}}</p>
            <p>Due Date: {{tasksCtrl.printDate(task.DueDate)}}</p>
        </div>
    </div>
</body>
</html>

```

Ahora agregamos el filtro, al igual que como hicimos la última vez.


```html

<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="../Scripts/angular.min.js"></script>
    <script src="../Scripts/app/app.js"></script>
    <script src="../Scripts/tasks/tasksController.js"></script>
</head>
<body ng-app="Tresana">
    <div ng-controller="Tasks.Controller as tasksCtrl">
        Filter by:
        <input type="text" ng-model="tasksCtrl.filter"/>
        Order by:
        <select ng-model="tasksCtrl.orderBy">
            <option value="StartDate">Start Date</option>
            <option value="CreationDate">Creation Date</option>
        </select>

        <div ng-repeat="task in tasksCtrl.tasks | orderBy: tasksCtrl.orderBy | filter: tasksCtrl.filter">
            <h2>Task Name: {{task.Name}}</h2>
            <p>Description: {{task.Description}}</p>
            <p>Creation Date: {{tasksCtrl.printDate(task.CreationDate)}}</p>
            <p>Start Date: {{tasksCtrl.printDate(task.StartDate)}}</p>
            <p>Due Date: {{tasksCtrl.printDate(task.DueDate)}}</p>
        </div>
    </div>
</body>
</html>

```

Listo! Así concluye nuestra primer aplicación Angular. 
Para repasar, hoy vimos:

- Como inicializar una aplicación Angular.
- Como crear Controllers.
- Notación Controller as
- Directivas ```ng-app```, ```ng-controller```, ```ng-repeat``` y ```ng-model```.
- Interpolación de texto.
- Filtros
