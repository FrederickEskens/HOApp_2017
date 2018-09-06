package scoutsengidsenvlaanderen.be.hogids.fragments;


import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import scoutsengidsenvlaanderen.be.hogids.PracticalViewPagerAdapter;
import scoutsengidsenvlaanderen.be.hogids.R;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link ProgramFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class ProgramFragment extends Fragment {

    TabLayout tabLayot;
    ViewPager viewPager;

    private PracticalViewPagerAdapter viewPagerAdapter;
    public ProgramFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @return A new instance of fragment ProgramFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static ProgramFragment newInstance(String param1, String param2) {
        ProgramFragment fragment = new ProgramFragment();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        viewPagerAdapter = new PracticalViewPagerAdapter(getFragmentManager());
        viewPagerAdapter.addFragment(ProgramDayFragment.newInstance(1), "Vrijdag");
        viewPagerAdapter.addFragment(ProgramDayFragment.newInstance(2), "Zaterdag");
        viewPagerAdapter.addFragment(ProgramDayFragment.newInstance(3), "Zondag");
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_program, container, false);

        tabLayot = view.findViewById(R.id.programTabLayout);
        viewPager = view.findViewById(R.id.programViewPager);

        viewPager.setAdapter(viewPagerAdapter);
        viewPager.setOffscreenPageLimit(viewPagerAdapter.getCount());

        tabLayot.setupWithViewPager(viewPager);
        tabLayot.setTabGravity(TabLayout.GRAVITY_FILL);

        return view;
    }

}
