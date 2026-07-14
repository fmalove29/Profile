import type { ProfileData } from '../../types/profile'
import { SectionHeading } from '../ui/SectionHeading'

type ContactSectionProps = {
  profile: ProfileData
}

export function ContactSection({ profile }: ContactSectionProps) {
  return (
    <section className="px-6 py-16 sm:px-10 lg:px-14">
      <div className="mx-auto grid max-w-7xl gap-8 rounded-[2rem] border border-stone-200 bg-white p-8 shadow-[0_24px_70px_-34px_rgba(41,37,36,0.3)] lg:grid-cols-[0.95fr_1.05fr] lg:p-10">
        <SectionHeading
          eyebrow="Contact"
          title="Let’s connect for web or application development opportunities."
          description="The page is structured so your core contact details remain immediate and easy to scan on both desktop and mobile."
        />

        <div className="grid gap-4">
          {profile.contactLinks.map((item) => (
            <a
              key={item.label}
              href={item.href}
              target={item.href.startsWith('http') ? '_blank' : undefined}
              rel={item.href.startsWith('http') ? 'noreferrer' : undefined}
              className="rounded-[1.5rem] border border-stone-200 bg-stone-50 px-5 py-4 transition hover:-translate-y-0.5 hover:bg-stone-100"
            >
              <p className="text-xs font-semibold uppercase tracking-[0.32em] text-stone-500">
                {item.label}
              </p>
              <p className="mt-2 break-all text-lg font-medium text-stone-900">
                {item.value}
              </p>
            </a>
          ))}
        </div>
      </div>
    </section>
  )
}
