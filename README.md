# xmen-challenge
X-men challenge. Finding x-men for Magneto's army.

## Dominio del problema

Magneto quiere reclutar la mayor cantidad de mutantes para poder luchar contra los X-Men. Te ha contratado a ti para que desarrolles un proyecto que detecte si un humano es mutante basándose en su secuencia de ADN. Para eso te ha pedido crear un programa con un método o función con la siguiente firma: boolean isMutant(String[] dna).

En donde recibirás como parámetro un array de Strings que representan cada fila de una tabla de (NxN) con la secuencia del ADN. Las letras de los Strings solo pueden ser: (A,T,C,G), las cuales representa cada base nitrogenada del ADN. Sabrás si un humano es mutante, si encuentras más de una secuencia de cuatro letras iguales, de forma oblicua, horizontal o vertical.

### Ejemplo (Caso mutante):
String[] dna = {"ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"}; 
//En este caso el llamado a la función isMutant(dna) devuelve “true”

El desafio consta de tres niveles

Nivel 1:
Programa (en cualquier lenguaje de programación) que cumpla con el método pedido por Magneto.

Nivel 2:
Crear una API REST, hostear esa API en un cloud computing libre (Google App Engine, Amazon AWS, etc), crear el servicio “/mutant/” en donde se pueda detectar si un humano es
mutante enviando la secuencia de ADN mediante un HTTP POST con un Json el cual tenga el siguiente formato:
POST → /mutant/
{
  "dna":["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"]
}
En caso de verificar un mutante, debería devolver un HTTP 200-OK, en caso contrario un 403-Forbidden.


Nivel 3:
Anexar una base de datos, la cual guarde los ADN’s verificados con la API. Solo 1 registro por ADN.
Exponer un servicio extra “/stats” que devuelva un Json con las estadísticas de las verificaciones de ADN: {“count_mutant_dna”:40, “count_human_dna”:100: “ratio”:0.4}
Tener en cuenta que la API puede recibir fluctuaciones agresivas de tráfico (Entre 100 y 1 millón de peticiones por segundo).

## Entregables
API REST URI'S:

POST: https://brainservicesapi20200629110951.azurewebsites.net/api/mutant

GET:  https://brainservicesapi20200629110951.azurewebsites.net/api/stats

Adicionalmente, se ha expuesto el siguiente recurso para retornar detalles del analisis de la secuencia de ADN.

POST: https://brainservicesapi20200629110951.azurewebsites.net/api/laboratory

El resultado de este analisis se presenta de la siguiente forma:
{
    "IsMutant": true,
    "MutantSequences": [
        "AAAATA",
        "CCCCTA",
        "GGGGTT"
    ],
    "ConclusionOfAnalysis": "This guy is a mutant. Magneto will be happy to know it."
}

{
    "IsMutant": false,
    "MutantSequences": [],
    "ConclusionOfAnalysis": "Invalid DNA sample. There are invalid characters in the DNA sequence. Valid characters must be A, T, C, G."
}

{
    "IsMutant": false,
    "MutantSequences": [],
    "ConclusionOfAnalysis": "Invalid DNA sample. N must be the number of sequences and characters into all sequences. No nxn array to analyze."
}

## Diseño

El diseño técnico del proyecto corresponde a un modelo de 3-capas: Servicios, Negocio y Datos. Las unidades de datos existentes entre capas corresponden a entidades, modelos y DTO's. Los criterios de diseños se priorizaron en el siguiente orden: escalabilidad de la solución, consistencia y rendimiento.

Las validaciones previas al analisis de la secuencia de ADN garantizan no procesar: secuencias nulas, secuencias con caracteres invalidos, secuencias incompletas o formatos invalidos. La solución es non-sensitive.

Para la logica de negocio, se manejaron dos componentes: Mutant y Laboratory. Muntant tiene la logica necesaria para identificar genes mutantes y laboratory para gestionar el resultado de los analisis. A nivel de DAL, solo fue necesario crear el componente de Laboratory.

## Tecnología
La solución se ha construido utilizando:

c#
.Net Framework 4.7.2,
Entity Framework 6.0,
API Rest 2.1,
Microsoft Azure Services,
SQL Server 13.0

¿Por que se decidió utilizar tecnologias microsoft? R:/ Por velocidad de desarrollo.

## Posibles mejoras
* Implementar un logger para registrar y monitorear eventos.
* Realizar pruebas de cargar para monitorizar el comportamiento del rest api.
* Implementar ax. de infraestructura para alto volumen de trafico.
* Generar documentación técnica diagramas de componentes, clases y distribución.
