API-Meter.NET
========

API-Meter.NET is a project on top of the .NET Framework to aggregate metrics about
 API's of various kinds using a fully customizable set of rules.

This tool relies on the following main components:
* An HTTP Module to capture all the incoming requests to a .NET API
* A set of processing rules defined on the incoming traffic
* A data provider model to put the denormalized data into a temporary storage system
* A Windows Service that aggregates denormalized data into a normalized structure
* A data provider to store the normalized data into a permanent storage system
* A web-based tool with real-time capabilities to view the metrics visually
