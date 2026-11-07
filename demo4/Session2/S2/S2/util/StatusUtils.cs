using System;
using System.Linq;
using S2.data.db.model;

namespace S2.util
{

    public static class StatusUtils
    {
        public const string Pending = "Pending";
        public const string Approved = "Approved";
        public const string Rejected = "Rejected";

        public const string NotStarted = "Not Started";
        public const string InitialInspection = "Initial Inspection";
        public const string UnsealingInspection = "Unsealing Inspection";
        public const string Exception = "Exception";
        public const string Released = "Released";
        public const string Seized = "Seized";
        public const string Handled = "Handled";

        // get status id
        public static int getDeclarationId(S2DBEntities db, string status)
        {
            return db.declaration_status
                .AsNoTracking()
                .Where(s => s.status == status)
                .Select(s => s.id)
                .First();
        }

        public static int getSecurityId(S2DBEntities db, string status)
        {
            return db.security_check_status
                .AsNoTracking()
                .Where(s => s.status == status)
                .Select(s => s.id)
                .First();
        }

        public static void setDeclaration(S2DBEntities db, declaration item,
            string status, string reason)
        {
            setDeclaration(db, item, getDeclarationId(db, status), reason);
        }
        public static void setDeclaration(S2DBEntities db, declaration item,
            int statusId, string reason)
        {
            item.declaration_status_id = statusId;
            db.declaration_status_change.Add(new declaration_status_change
            {
                declaration_id = item.id,
                declaration_status_id = statusId,
                change_time = DateTime.Now,
                reason = reason
            });
        }

        public static void setSecurity(S2DBEntities db, security_check item,
            string status)
        {
            setSecurity(db, item, getSecurityId(db, status));
        }

        public static void setSecurity(S2DBEntities db, security_check item,
            int statusId)
        {
            item.current_status = statusId;
            db.sc_status_change.Add(new sc_status_change
            {
                security_check_id = item.id,
                sc_status_id = statusId,
                change_time = DateTime.Now
            });
        }
    }
}
