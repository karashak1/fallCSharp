using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using DataAccess.Models;

namespace Web2MVC.Controllers
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    
    */
    public class ODataContactsController : ODataController
    {
        private CSharpContext db = new CSharpContext();

        // GET odata/ODataContacts
        [Queryable]
        public IQueryable<Contact> GetODataContacts()
        {
            return db.Contacts;
        }

        // GET odata/ODataContacts(5)
        [Queryable]
        public SingleResult<Contact> GetContact([FromODataUri] int key)
        {
            return SingleResult.Create(db.Contacts.Where(contact => contact.Id == key));
        }

        // PUT odata/ODataContacts(5)
        public IHttpActionResult Put([FromODataUri] int key, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != contact.Id)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(contact);
        }

        // POST odata/ODataContacts
        public IHttpActionResult Post(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contacts.Add(contact);
            db.SaveChanges();

            return Created(contact);
        }

        // PATCH odata/ODataContacts(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Contact> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contact contact = db.Contacts.Find(key);
            if (contact == null)
            {
                return NotFound();
            }

            patch.Patch(contact);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(contact);
        }

        // DELETE odata/ODataContacts(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Contact contact = db.Contacts.Find(key);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contact);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/ODataContacts(5)/Addresses
        [Queryable]
        public IQueryable<Address> GetAddresses([FromODataUri] int key)
        {
            return db.Contacts.Where(m => m.Id == key).SelectMany(m => m.Addresses);
        }

        // GET odata/ODataContacts(5)/ContactMethods
        [Queryable]
        public IQueryable<ContactMethod> GetContactMethods([FromODataUri] int key)
        {
            return db.Contacts.Where(m => m.Id == key).SelectMany(m => m.ContactMethods);
        }

        // GET odata/ODataContacts(5)/Keyword
        [Queryable]
        public SingleResult<Keyword> GetKeyword([FromODataUri] int key)
        {
            return SingleResult.Create(db.Contacts.Where(m => m.Id == key).Select(m => m.Keyword));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int key)
        {
            return db.Contacts.Count(e => e.Id == key) > 0;
        }
    }
}
