API-Meter.NET
========

API-Meter.NET is a project on top of the .NET Framework to aggregate metrics about
 API's of various kinds using a fully customizable set of rules.  This tool uses a
 provider model to capture all the incoming requests to an ASP.NET application
 using an HTTP Module, processes them based on a set of rules defined by user,
 inserts them into a temporary storage (Redis or any other implementation of
 the data provider), and then aggregates them into a normalized form into a
 storage system (RavenDB or any other implementation of the data provider)
 for ease of viewing using a Windows Service to run on a regular basis.  There
 is a default web viewer provided using HTML5, CSS3, jQuery, and ASP.NET
 SignalR that allows viewing of these reports in a simple way in real time.
