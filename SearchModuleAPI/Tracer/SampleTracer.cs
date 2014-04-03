using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Tracing;

namespace SearchModuleAPI.Tracer
{
    public class SampleTracer : ITraceWriter
    {
        List<TraceRecord> begin = new List<TraceRecord>();
        List<TraceRecord> end = new List<TraceRecord>();

        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            TraceRecord rec = new TraceRecord(request, category, level);
            traceAction(rec);
            WriteTrace(rec);
        }

        // Collect traces in memory.
        protected void WriteTrace(TraceRecord rec)
        {
            switch (rec.Kind)
            {
                case TraceKind.Begin:
                    begin.Add(rec);
                    break;

                case TraceKind.End:
                    end.Add(rec);
                    break;
            }
        }

        // Match "begin" and "end" traces and calculate the timing.
        public IEnumerable<PerfRecord> GetPerformanceRecords()
        {
            var records = new List<PerfRecord>();
            foreach (var rec in begin)
            {
                var index = end.FindIndex((r) =>
                    (rec.RequestId == r.RequestId && rec.Category == r.Category &&
                        rec.Operation == r.Operation && rec.Operator == r.Operator));
                if (index != -1)
                {
                    var match = end[index];
                    records.Add(new PerfRecord()
                    {
                        Msec = (match.Timestamp - rec.Timestamp).TotalMilliseconds,
                        Operation = rec.Operation,
                        Category = rec.Category,
                        RequestId = rec.RequestId
                    });
                    end.RemoveAt(index);
                }
            }
            begin.Clear();
            end.Clear();
            return records;
        }

    }
}