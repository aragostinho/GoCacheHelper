# GoCacheHelper
A C# Helper that works with GoCache APIs focused on removing objects from Cache.

# About GoCache
The biggest CDN from Brazil. https://www.gocache.com.br/

 

# GoCacheService Class 

**const string goCacheKey**

A GoCache key generated from GoCache Dashboard
 
**string goCacheUrlAPI**

The GoCache REST API url 

**string mainDomain**

The client domain configured to use GoCache

**GoCacheResponse Remove(string url)**

Remove one object per request from cache

**GoCacheResponse Remove(string[] urls)**

Remove N objects per request from cache
